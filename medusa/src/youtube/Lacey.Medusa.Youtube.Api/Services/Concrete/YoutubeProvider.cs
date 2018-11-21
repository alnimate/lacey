using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Base.Upload;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Api.Extensions;
using Lacey.Medusa.Youtube.Api.Models.Enums;
using Lacey.Medusa.Youtube.Api.Video.Base.Core;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Lacey.Medusa.Youtube.Api.Services.Concrete
{
    public sealed class YoutubeProvider : IYoutubeProvider
    {
        #region properties/constructors

        private readonly YouTubeService youtube;

        private readonly ILogger logger;

        public YoutubeProvider(
            IYoutubeAuthProvider youtubeAuthProvider,
            ILogger<YoutubeProvider> logger)
        {
            this.logger = logger;

            this.youtube = new YouTubeService(new BaseClientService.Initializer
            {
                HttpClientInitializer = youtubeAuthProvider.GetUserCredentials().Result,
                ApplicationName = GetType().ToString()
            });
        }

        #endregion

        #region videos

        public async Task<IReadOnlyList<Base.Video>> GetVideos(string channelId)
        {
            var videosIds = await this.GetVideoIds(channelId);
            var request = this.youtube.Videos.List(VideoParts.AllAnonymous.AsListParam());
            request.Id = videosIds.AsListParam();
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

        public async Task<IReadOnlyList<string>> GetVideoIds(string channelId)
        {
            var request = this.youtube.Search.List(VideoParts.Id);
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

        public async Task<string> DownloadVideo(string videoId, string outputFolder)
        {
            var video = await Task.Run(() =>
            {
                using (var service = Client.For(YouTube.Default))
                {
                    return service.GetVideo("https://youtube.com/watch?v=" + videoId);
                }
            });

            Directory.CreateDirectory(outputFolder);
            var outputFilePath = Path.Combine(outputFolder, $"VID-{Guid.NewGuid()}{video.FileExtension}");
            File.WriteAllBytes(outputFilePath, video.GetBytes());
            return outputFilePath;
        }

        public async Task<Base.Video> UploadVideo(
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
                videoUpdate.Snippet.ChannelId = channelId;

                var args = new[]
                {
                    VideoParts.Snippet,
                    VideoParts.Status,
                    VideoParts.RecordingDetails,
                };
                var request = this.youtube.Videos.Insert(videoUpdate, args.AsListParam(), fileStream, "video/*");
                request.ProgressChanged += OnProgressChanged;
                request.ResponseReceived += OnResponseReceived;

                await request.UploadAsync();

                // load max res video thumbnail
                var videoImage = await this.youtube.HttpClient
                    .GetAsync(video.Snippet.Thumbnails.Maxres.Url);
                var thumbnailsRequest = this.youtube.Thumbnails.Set(
                    request.ResponseBody.Id,
                    await videoImage.Content.ReadAsStreamAsync(),
                    MediaTypeNames.Image.Jpeg);
                // upload thumbnail for our video to the youtube
                await thumbnailsRequest.UploadAsync();

                return request.ResponseBody;
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

        public async Task<string> DeleteVideo(string videoId)
        {
            var request = this.youtube.Videos.Delete(videoId);
            return await request.ExecuteAsync();
        }

        #endregion

        #region playlists

        public async Task<IList<Playlist>> GetPlaylists(string channelId)
        {
            var request = this.youtube.Playlists.List(PlaylistParts.All.AsListParam());
            request.ChannelId = channelId;
            request.MaxResults = 50;

            var list = new List<Playlist>();
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

        public async Task<IList<Playlist>> UploadPlaylists(string channelId, IList<Playlist> playlists)
        {
            var list = new List<Playlist>();
            foreach (var playlist in playlists)
            {
                var playlistUpdate = new Playlist();
                playlistUpdate.Snippet = playlist.Snippet;
                playlistUpdate.Snippet.ChannelId = channelId;
                playlistUpdate.Status = playlist.Status;

                var parts = new[]
                {
                    PlaylistParts.Snippet,
                    PlaylistParts.Status,
                };
                var request = this.youtube.Playlists.Insert(playlistUpdate, parts.AsListParam());
                list.Add(await request.ExecuteAsync());
            }

            return list;
        }

        public async Task DeletePlaylists(string channelId)
        {
            var request = this.youtube.Playlists.List(PlaylistParts.Id);
            request.ChannelId = channelId;
            request.MaxResults = 50;

            var items = new List<Playlist>();
            var nextPageToken = string.Empty;
            while (nextPageToken != null)
            {
                request.PageToken = nextPageToken;
                var response = await request.ExecuteAsync();

                items.AddRange(response.Items);

                nextPageToken = response.NextPageToken;
            }

            foreach (var item in items)
            {
                var deleteRequest = this.youtube.Playlists.Delete(item.Id);
                await deleteRequest.ExecuteAsync();
            }
        }

        #endregion

        #region subscriptions

        public async Task<IList<Subscription>> GetSubscriptions(string channelId)
        {
            var request = this.youtube.Subscriptions.List(SubscriptionParts.AllAnonymous.AsListParam());
            request.ChannelId = channelId;
            request.MaxResults = 50;

            var list = new List<Subscription>();
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

        public async Task<IList<Subscription>> UploadSubscriptions(string channelId, IList<Subscription> subscriptions)
        {
            var list = new List<Subscription>();
            foreach (var subscription in subscriptions)
            {
                var subscriptionUpdate = new Subscription();
                subscriptionUpdate.Snippet = subscription.Snippet;
                subscriptionUpdate.Snippet.ChannelId = channelId;

                var request = this.youtube.Subscriptions.Insert(subscriptionUpdate, SubscriptionParts.Snippet);
                list.Add(await request.ExecuteAsync());
            }

            return list;
        }

        public async Task DeleteSubscriptions(string channelId)
        {
            var request = this.youtube.Subscriptions.List(SubscriptionParts.Id);
            request.ChannelId = channelId;
            request.MaxResults = 50;

            var items = new List<Subscription>();
            var nextPageToken = string.Empty;
            while (nextPageToken != null)
            {
                request.PageToken = nextPageToken;
                var response = await request.ExecuteAsync();

                items.AddRange(response.Items);

                nextPageToken = response.NextPageToken;
            }

            foreach (var item in items)
            {
                var deleteRequest = this.youtube.Subscriptions.Delete(item.Id);
                await deleteRequest.ExecuteAsync();
            }
        }

        #endregion

        #region comments

        public async Task<IList<CommentThread>> GetComments(string channelId)
        {
            var request = this.youtube.CommentThreads.List(CommentParts.All.AsListParam());
            request.ChannelId = channelId;
            request.MaxResults = 50;

            var list = new List<CommentThread>();
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

        public async Task<IList<CommentThread>> UploadComments(string channelId, IList<CommentThread> comments)
        {
            var list = new List<CommentThread>();
            foreach (var comment in comments)
            {
                comment.Snippet.ChannelId = channelId;
                var request = this.youtube.CommentThreads.Insert(comment, CommentParts.Snippet);
                list.Add(await request.ExecuteAsync());
            }

            return list;
        }

        public async Task DeleteComments(string channelId)
        {
            var request = this.youtube.CommentThreads.List(CommentParts.Id);
            request.ChannelId = channelId;
            request.MaxResults = 50;

            var items = new List<CommentThread>();
            var nextPageToken = string.Empty;
            while (nextPageToken != null)
            {
                request.PageToken = nextPageToken;
                var response = await request.ExecuteAsync();

                items.AddRange(response.Items);

                nextPageToken = response.NextPageToken;
            }

            foreach (var item in items)
            {
                var deleteRequest = this.youtube.Comments.Delete(item.Id);
                await deleteRequest.ExecuteAsync();
            }
        }

        #endregion

        #region metadata

        public async Task<Channel> GetChannel(string channelId)
        {
            var request = this.youtube.Channels.List(ChannelParts.AllAnonymous.AsListParam());
            request.Id = channelId;
            var response = await request.ExecuteAsync();
            return response.Items.First();
        }

        public async Task<Channel> UpdateMetadata(string channelId, Channel channel)
        {
            var channelUpdate = new Channel();
            channelUpdate.Id = channelId;
            channelUpdate.BrandingSettings = channel.BrandingSettings;

            // we can't change some properties from brandingSettings request
            channelUpdate.BrandingSettings.Channel.Title = string.Empty;
            channelUpdate.BrandingSettings.Channel.UnsubscribedTrailer = string.Empty;

            // set banner
            // load max res channel banner
            var banner = await this.UploadChannelBanner(channel.BrandingSettings.Image.BannerTvHighImageUrl);
            channelUpdate.BrandingSettings.Image.BannerExternalUrl = banner.Url;

            var request = this.youtube.Channels.Update(channelUpdate, ChannelParts.BrandingSettings);
            return await request.ExecuteAsync();
        }

        public async Task DeleteMetadata(string channelId)
        {
            var channelUpdate = new Channel();
            channelUpdate.Id = channelId;
            channelUpdate.BrandingSettings = new ChannelBrandingSettings();

            var request = this.youtube.Channels.Update(channelUpdate, ChannelParts.BrandingSettings);
            await request.ExecuteAsync();
        }

        public async Task<string> DownloadIcon(Channel channel, string outputFolder)
        {
            string iconUrl;
            if (channel.Snippet.Thumbnails.Maxres != null)
            {
                iconUrl = channel.Snippet.Thumbnails.Maxres.Url;
            }
            else if (channel.Snippet.Thumbnails.High != null)
            {
                iconUrl = channel.Snippet.Thumbnails.High.Url;
            }
            else if (channel.Snippet.Thumbnails.Medium != null)
            {
                iconUrl = channel.Snippet.Thumbnails.Medium.Url;
            }
            else if (channel.Snippet.Thumbnails.Standard != null)
            {
                iconUrl = channel.Snippet.Thumbnails.Standard.Url;
            }
            else if (channel.Snippet.Thumbnails.Default__ != null)
            {
                iconUrl = channel.Snippet.Thumbnails.Default__.Url;
            }
            else
            {
                return null;
            }

            var icon = await this.youtube.HttpClient.GetAsync(iconUrl);
            Directory.CreateDirectory(outputFolder);
            var outputFilePath = Path.Combine(outputFolder, $"ICON-{Guid.NewGuid()}.jpg");
            File.WriteAllBytes(outputFilePath, await icon.Content.ReadAsByteArrayAsync());
            return outputFilePath;
        }

        private async Task<ChannelBannerResource> UploadChannelBanner(string bannerUrl)
        {
            // load max res channel banner
            var bannerImage = await this.youtube.HttpClient.GetAsync(bannerUrl);
            using (var image = Image.Load(await bannerImage.Content.ReadAsStreamAsync()))
            using (var ms = new MemoryStream())
            {
                // rescale banner. it is youtube requirements
                image.Mutate(x => x
                    .Resize(2560, 1440));
                image.SaveAsJpeg(ms);

                // upload our banner to the youtube
                var bannerRequest = this.youtube.ChannelBanners.Insert(
                    new ChannelBannerResource(),
                    ms,
                    MediaTypeNames.Image.Jpeg);

                await bannerRequest.UploadAsync();

                return bannerRequest.ResponseBody;
            }
        }

        #endregion
    }
}