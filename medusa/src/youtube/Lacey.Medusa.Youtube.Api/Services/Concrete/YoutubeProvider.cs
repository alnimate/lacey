﻿using System;
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
            var request = this.youtube.Channels.List(ChannelPart.AllAnonymous.AsListParam());
            request.Id = channelId;
            var response = await request.ExecuteAsync();
            return response.Items.First();
        }

        public async Task<Channel> UpdateChannelInfo(Channel channelToUpdate)
        {
            return channelToUpdate;

            var channel = new Channel();
            var brandingSettings = new ChannelBrandingSettings();
            var channelSettings = new ChannelSettings
            {
                ShowBrowseView = false,
                ShowRelatedChannels = false
            };

            brandingSettings.Channel = channelSettings;
            channel.BrandingSettings = brandingSettings;

            var request = this.youtubeOAuth2.Channels.Update(channel, ChannelPart.BrandingSettings);
            request.OnBehalfOfContentOwner = string.Empty;
            return await request.ExecuteAsync();
        }

        public async Task<IReadOnlyList<Base.Video>> GetChannelVideos(string channelId)
        {
            var channelVideosIds = await this.GetChannelVideoIds(channelId);
            var args = new[]
            {
                VideoPart.Snippet
            };
            var request = this.youtube.Videos.List(args.AsListParam());
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
                var args = new []
                {
                    VideoPart.Snippet,
                    VideoPart.Status
                };
                var request = this.youtubeOAuth2.Videos.Insert(video, args.AsListParam(), fileStream, "video/*");
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