using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Base.Upload;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Api.Models.Enums;
using Lacey.Medusa.Youtube.Api.Video.Base.Core;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Api.Services.Concrete
{
    public sealed class YoutubeProvider : IYoutubeProvider
    {
        private readonly YouTubeService youtube;

        private readonly YouTubeService youtubeOAuth2;

        private readonly ILogger logger;

        private readonly string outputFolder;

        public YoutubeProvider(
            IYoutubeAuthProvider youtubeAuthProvider, 
            ILogger<YoutubeProvider> logger,
            string outputFolder)
        {
            this.logger = logger;
            this.outputFolder = outputFolder;
            var applicationName = GetType().ToString();
            this.youtube = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = youtubeAuthProvider.GetApiKey(),
                ApplicationName = applicationName
            });

            this.youtubeOAuth2 = new YouTubeService(new BaseClientService.Initializer
            {
                HttpClientInitializer = youtubeAuthProvider.GetUserCredentials().Result,
                ApplicationName = applicationName
            });
        }

        public async Task<Channel> GetChannelInfo(string channelId)
        {
            var args = new []
            {
                "snippet",
                "brandingSettings"
            };
            var request = this.youtube.Channels.List(string.Join(',', args));
            request.Id = channelId;
            var response = await request.ExecuteAsync();
            return response.Items.First();
        }

        public async Task<IReadOnlyList<SearchResult>> GetChannelVideos(string channelId)
        {
            var request = this.youtube.Search.List("snippet");
            request.Order = SearchResource.ListRequest.OrderEnum.Date;
            request.MaxResults = 50;
            request.ChannelId = channelId;

            var list = new List<SearchResult>();
            var nextPageToken = string.Empty;
            while (nextPageToken != null)
            {
                request.PageToken = nextPageToken;
                var response = await request.ExecuteAsync();

                list.AddRange(
                    response.Items.Where(i => i.Id.Kind == SearchResultType.Video));

                nextPageToken = response.NextPageToken;
            }

            return list;
        }

        public async Task<string> DownloadVideo(string videoId)
        {
            this.logger.LogTrace($"Downloading video [{videoId}]...");
            var video = await Task.Run(() =>
            {
                using (var service = Client.For(YouTube.Default))
                {
                    return service.GetVideo("https://youtube.com/watch?v=" + videoId);
                }
            });

            Directory.CreateDirectory(this.outputFolder);
            var outputFilePath = Path.Combine(this.outputFolder,
                $"VID-{Guid.NewGuid()}{video.FileExtension}");
            File.WriteAllBytes(outputFilePath, video.GetBytes());
            this.logger.LogTrace($"Downloaded video [{videoId}] to [{outputFilePath}]");
            return outputFilePath;
        }

        public async Task UploadVideo(
            string channelId,
            Base.Video video,
            string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var videosInsertRequest = this.youtubeOAuth2.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                videosInsertRequest.ProgressChanged += OnProgressChanged;
                videosInsertRequest.ResponseReceived += OnResponseReceived;

                await videosInsertRequest.UploadAsync();
            }
        }

        private void OnProgressChanged(IUploadProgress progress)
        {
            this.logger.LogTrace($"Bytes sent {progress.BytesSent}. Status {progress.Status}.");
        }


        private void OnResponseReceived(Base.Video video)
        {
            this.logger.LogTrace($"Video '{video.Snippet.Title}' uploaded.");
        }
    }
}