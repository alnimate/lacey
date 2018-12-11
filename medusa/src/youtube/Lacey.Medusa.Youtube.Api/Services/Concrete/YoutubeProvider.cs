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
using Lacey.Medusa.Youtube.Api.Models.Const;
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
            request.MaxResults = ListConsts.MaxResults;

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
            request.MaxResults = ListConsts.MaxResults;
            request.ChannelId = channelId;

            var list = new List<string>();
            var nextPageToken = string.Empty;
            while (nextPageToken != null)
            {
                request.PageToken = nextPageToken;
                var response = await request.ExecuteAsync();

                list.AddRange(response.Items.Where(i => i.Id.Kind == ResourceKind.Video)
                        .Select(v => v.Id.VideoId));

                nextPageToken = response.NextPageToken;
            }

            return list;
        }

        public async Task<string> DownloadVideo(string videoId, string outputFolder)
        {
            using (var service = Client.For(YouTube.Default))
            {
                var video = await service.GetVideoAsync("https://youtube.com/watch?v=" + videoId);
                Directory.CreateDirectory(outputFolder);
                var outputFilePath = Path.Combine(outputFolder, $"VID-{Guid.NewGuid()}{video.FileExtension}");
                File.WriteAllBytes(outputFilePath, await video.GetBytesAsync());
                return outputFilePath;
            }
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
            request.MaxResults = ListConsts.MaxResults;

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

        public async Task<Playlist> UploadPlaylist(string channelId, Playlist playlist)
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
            return await request.ExecuteAsync();
        }

        public async Task DeletePlaylists(string channelId)
        {
            var request = this.youtube.Playlists.List(PlaylistParts.Id);
            request.ChannelId = channelId;
            request.MaxResults = ListConsts.MaxResults;

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

        #region playlist items

        public async Task<IList<PlaylistItem>> GetPlaylistItems(string playlistId)
        {
            var request = this.youtube.PlaylistItems.List(PlaylistItemParts.All.AsListParam());
            request.PlaylistId = playlistId;
            request.MaxResults = ListConsts.MaxResults;

            var list = new List<PlaylistItem>();
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

        public async Task<PlaylistItem> UploadPlaylistItem(
            string channelId,
            string playlistId, 
            PlaylistItem playlistItem)
        {
            var update = new PlaylistItem();
            update.Snippet = playlistItem.Snippet;
            update.Snippet.ChannelId = channelId;
            update.Snippet.PlaylistId = playlistId;
            update.Status = playlistItem.Status;

            var parts = new[]
            {
                PlaylistItemParts.Snippet,
                PlaylistItemParts.Status
            };
            var request = this.youtube.PlaylistItems.Insert(update, parts.AsListParam());
            return await request.ExecuteAsync();
        }

        public async Task DeletePlaylistItems(string playlistId)
        {
            var request = this.youtube.PlaylistItems.List(PlaylistParts.Id);
            request.PlaylistId = playlistId;
            request.MaxResults = ListConsts.MaxResults;

            var items = new List<PlaylistItem>();
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
                var deleteRequest = this.youtube.PlaylistItems.Delete(item.Id);
                await deleteRequest.ExecuteAsync();
            }
        }


        #endregion

        #region sections

        public async Task<IList<ChannelSection>> GetSections(string channelId)
        {
            var request = this.youtube.ChannelSections.List(SectionParts.All.AsListParam());
            request.ChannelId = channelId;
            var response = await request.ExecuteAsync();

            return response.Items;
        }

        public async Task<IList<ChannelSection>> UploadSections(string channelId, IList<ChannelSection> sections)
        {
            var list = new List<ChannelSection>();
            foreach (var section in sections)
            {
                var sectionUpdate = new ChannelSection();
                sectionUpdate.Snippet = section.Snippet;
                sectionUpdate.ContentDetails = section.ContentDetails;
                sectionUpdate.Localizations = section.Localizations;
                sectionUpdate.Targeting = section.Targeting;
                sectionUpdate.Snippet.ChannelId = channelId;

                var parts = new []
                {
                    SectionParts.Snippet,
                    SectionParts.ContentDetails,
                    SectionParts.Localizations,
                    SectionParts.Targeting
                };

                var request = this.youtube.ChannelSections.Insert(sectionUpdate, parts.AsListParam());
                list.Add(await request.ExecuteAsync());
            }

            return list;
        }

        public async Task DeleteSections(string channelId)
        {
            var request = this.youtube.ChannelSections.List(SectionParts.Id);
            request.ChannelId = channelId;

            var response = await request.ExecuteAsync();

            foreach (var item in response.Items)
            {
                var deleteRequest = this.youtube.ChannelSections.Delete(item.Id);
                await deleteRequest.ExecuteAsync();
            }
        }

        #endregion

        #region subscriptions

        public async Task<IList<Subscription>> GetSubscriptions(string channelId)
        {
            var request = this.youtube.Subscriptions.List(SubscriptionParts.AllAnonymous.AsListParam());
            request.ChannelId = channelId;
            request.MaxResults = ListConsts.MaxResults;

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
                subscriptionUpdate.Snippet = new SubscriptionSnippet();
                subscriptionUpdate.Snippet.ResourceId = subscription.Snippet.ResourceId;
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
            request.MaxResults = ListConsts.MaxResults;

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
            request.MaxResults = ListConsts.MaxResults;

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
            request.MaxResults = ListConsts.MaxResults;

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
            var icon = await this.youtube.HttpClient.GetAsync(
                channel.Snippet.Thumbnails.GetMaxResUrl());
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