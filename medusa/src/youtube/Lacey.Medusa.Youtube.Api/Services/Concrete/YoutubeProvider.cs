using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Base.Upload;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Api.Extensions;
using Lacey.Medusa.Youtube.Api.Models.Enums;
using Lacey.Medusa.Youtube.Api.Video.Base.Core;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Api.Services.Concrete
{
    public sealed class YoutubeProvider : IYoutubeProvider
    {
        private readonly YouTubeService youtube;

        private readonly ILogger logger;

        private readonly string outputFolder;

        public YoutubeProvider(
            IYoutubeAuthProvider youtubeAuthProvider, 
            ILogger<YoutubeProvider> logger,
            string outputFolder)
        {
            this.logger = logger;
            this.outputFolder = outputFolder;

            this.youtube = new YouTubeService(new BaseClientService.Initializer
            {
                HttpClientInitializer = youtubeAuthProvider.GetUserCredentials().Result,
                ApplicationName = GetType().ToString()
            });
        }

        public async Task<Channel> GetChannelInfo(string channelId)
        {
            var request = this.youtube.Channels.List(ChannelPart.AllAnonymous.AsListParam());
            request.Id = channelId;
            var response = await request.ExecuteAsync();
            return response.Items.First();
        }

        public async Task<Channel> UpdateChannelInfo(Channel channel)
        {
            var bannerImage = await this.youtube.HttpClient
                .GetAsync(channel.BrandingSettings.Image.BannerTvHighImageUrl);
            Directory.CreateDirectory(this.outputFolder);
            var bannerFilePath = Path.Combine(this.outputFolder, $"BNR-{Guid.NewGuid()}.jpg");
            using (var fileStream = new FileStream(
                bannerFilePath,
                FileMode.Create, 
                FileAccess.ReadWrite))
            {
                var stream = await bannerImage.Content.ReadAsStreamAsync();
                await stream.CopyToAsync(fileStream);

                var banner = new ChannelBannerResource();
                var bannerRequest = this.youtube.ChannelBanners.Insert(
                    banner,
                    fileStream,
                    "image/jpeg");

                await bannerRequest.UploadAsync();

                var channelUpdate = new Channel();
                channelUpdate.Id = channel.Id;
                channelUpdate.BrandingSettings = channel.BrandingSettings;
                channelUpdate.BrandingSettings.Channel.Title = string.Empty;
                channelUpdate.BrandingSettings.Image.BannerExternalUrl = bannerRequest.ResponseBody.Url;

                var request = this.youtube.Channels.Update(channelUpdate, ChannelPart.BrandingSettings);
                return await request.ExecuteAsync();
            }
        }

        public async Task<IReadOnlyList<Base.Video>> GetChannelVideos(string channelId)
        {
            var channelVideosIds = await this.GetChannelVideoIds(channelId);
            var request = this.youtube.Videos.List(VideoPart.AllAnonymous.AsListParam());
            request.Id = channelVideosIds.AsListParam();
            request.MaxResults = 50;

            var list = new List<Base.Video>();
            var nextPageToken = string.Empty;
            while (nextPageToken != null)
            {
                request.PageToken = nextPageToken;
                var response = await request.ExecuteAsync();

                list.AddRange(response.Items);

                nextPageToken = response.NextPageToken;
            }

            return list;
        }

        private async Task<IReadOnlyList<string>> GetChannelVideoIds(string channelId)
        {
            var request = this.youtube.Search.List(VideoPart.Id);
            request.Order = SearchResource.ListRequest.OrderEnum.Date;
            request.MaxResults = 50;
            request.ChannelId = channelId;

            var list = new List<string>();
            var nextPageToken = string.Empty;
            while (nextPageToken != null)
            {
                request.PageToken = nextPageToken;
                var response = await request.ExecuteAsync();

                list.AddRange(response.Items.Where(i => i.Id.Kind == SearchResultKind.Video)
                        .Select(v => v.Id.VideoId));

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
            this.logger.LogTrace($"Video [{videoId}] downloaded to [{outputFilePath}]");
            return outputFilePath;
        }

        public async Task<IUploadProgress> UploadVideo(
            string channelId,
            Base.Video video,
            string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var videoUpdate = new Base.Video();
                videoUpdate.Snippet = video.Snippet;
                videoUpdate.Status = video.Status;
                videoUpdate.RecordingDetails = video.RecordingDetails;

                var args = new []
                {
                    VideoPart.Snippet,
                    VideoPart.Status,
                    VideoPart.RecordingDetails,
                };
                var request = this.youtube.Videos.Insert(videoUpdate, args.AsListParam(), fileStream, "video/*");
                request.ProgressChanged += OnProgressChanged;
                request.ResponseReceived += OnResponseReceived;

                return await request.UploadAsync();
            }
        }

        private void OnProgressChanged(IUploadProgress progress)
        {
            this.logger.LogTrace($"Bytes sent [{progress.BytesSent}]. Status [{progress.Status}].");
        }


        private void OnResponseReceived(Base.Video video)
        {
            this.logger.LogTrace($"Video [{video.Snippet.Title}] uploaded.");
        }
    }
}