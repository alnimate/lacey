using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Api.Services;
using Lacey.Medusa.Youtube.Services.Common.Services;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete
{
    public sealed class TransferService : YoutubeService, ITransferService
    {
        private readonly IChannelsService channelsService;

        private readonly IVideosService videosService;

        private readonly IPlaylistsService playlistsService;

        private readonly string outputFolder;

        public TransferService(
            IYoutubeProvider youtubeProvider, 
            ILogger<TransferService> logger, 
            string outputFolder, 
            IChannelsService channelsService, 
            IVideosService videosService, 
            IPlaylistsService playlistsService) : base(youtubeProvider, logger)
        {
            this.outputFolder = outputFolder;
            this.channelsService = channelsService;
            this.videosService = videosService;
            this.playlistsService = playlistsService;
        }

        public async Task TransferChannel(string sourceChannelId, string destChannelId)
        {
            await this.TransferComments(sourceChannelId, destChannelId);

            await this.TransferMetadata(sourceChannelId, destChannelId);

            await this.TransferVideos(sourceChannelId, destChannelId);

            await this.TransferPlaylists(sourceChannelId, destChannelId);

            await this.TransferSections(sourceChannelId, destChannelId);

            await this.TransferSubscriptions(sourceChannelId, destChannelId);
        }

        #region videos

        private async Task TransferVideos(string sourceChannelId, string destChannelId)
        {
            var sourceVideos = await this.YoutubeProvider.GetVideos(sourceChannelId);
            var dest = await this.YoutubeProvider.GetVideos(destChannelId);
            var destChannel = await this.channelsService.GetChannelMetadata(destChannelId);

            foreach (var sourceVideo in sourceVideos
                .Where(v => v.Snippet != null)
                .OrderBy(v => v.Snippet.PublishedAt))
            {
                // skip existing items
                if (dest.Any(d =>
                    sourceVideo.Snippet.Title == d.Snippet.Title &&
                    sourceVideo.Snippet.Description == d.Snippet.Description))
                {
                    this.Logger.LogTrace($"Video [{sourceVideo.Snippet.Title}] skipped. Video already exists.");
                    continue;
                }

                string filePath = null;
                try
                {
                    this.Logger.LogTrace($"Downloading video [{sourceVideo.Id}]...");
                    filePath = await this.YoutubeProvider.DownloadVideo(sourceVideo.Id, this.outputFolder);
                    this.Logger.LogTrace($"Video [{sourceVideo.Id}] downloaded to [{filePath}]");

                    var uploadedVideo = await this.YoutubeProvider.UploadVideo(destChannelId, sourceVideo, filePath);
                    await this.videosService.Add(destChannel.Id, sourceVideo.Id, uploadedVideo);
                }
                catch (Exception exc)
                {
                    this.Logger.LogError(exc.Message);
                }
                finally
                {
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
            }
        }

        #endregion

        #region playlists

        private async Task TransferPlaylists(string sourceChannelId, string destChannelId)
        {
            try
            {
                var sourcePlaylists = await this.YoutubeProvider.GetPlaylists(sourceChannelId);
                var destPlaylists = await this.YoutubeProvider.GetPlaylists(destChannelId);
                var destChannel = await this.channelsService.GetChannelMetadata(destChannelId);
                var destVideos = await this.videosService.GetTransferVideos(sourceChannelId, destChannelId);

                // skip existing items
                foreach (var sourcePlaylist in sourcePlaylists
                    .Where(p => p.Snippet != null)
                    .OrderBy(p => p.Snippet.PublishedAt))
                {
                    if (destPlaylists.Any(d =>
                        sourcePlaylist.Snippet.Title == d.Snippet.Title &&
                        sourcePlaylist.Snippet.Description == d.Snippet.Description))
                    {
                        continue;
                    }

                    var uploadedPlaylist = await this.YoutubeProvider.UploadPlaylist(destChannelId, sourcePlaylist);
                    await this.playlistsService.Add(destChannel.Id, sourcePlaylist.Id, uploadedPlaylist);

                    // insert playlist items
                    var playlistItems = await this.YoutubeProvider.GetPlaylistItems(sourcePlaylist.Id);
                    foreach (var item in playlistItems)
                    {
                        if (item.Snippet.ResourceId == null)
                        {
                            continue;
                        }

                        var destVideo = destVideos.FirstOrDefault(
                            l => l.OriginalVideoId == item.Snippet.ResourceId.VideoId);
                        if (destVideo != null)
                        {
                            item.Snippet.ResourceId.VideoId = destVideo.VideoId;
                        }
                        await this.YoutubeProvider.UploadPlaylistItem(destChannelId, uploadedPlaylist.Id, item);

                        if (destVideo != null)
                        {
                            await this.playlistsService.AddVideoToPlaylist(uploadedPlaylist.Id, destVideo.VideoId);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                this.Logger.LogError(exc.Message);
            }
        }

        #endregion

        #region sections

        private async Task TransferSections(string sourceChannelId, string destChannelId)
        {
            try
            {
                var source = await this.YoutubeProvider.GetSections(sourceChannelId);
                var dest = await this.YoutubeProvider.GetSections(destChannelId);
                var destPlaylists = await this.playlistsService.GetTransferPlaylists(sourceChannelId, destChannelId);

                // skip existing items
                var toUpload = new List<ChannelSection>();
                foreach (var item in source
                    .Where(s => s.Snippet != null))
                {
                    if (dest.Any(d =>
                        item.Snippet.Title == d.Snippet.Title &&
                        item.Snippet.Type == d.Snippet.Type))
                    {
                        continue;
                    }

                    // change section playlists from source to dest
                    if (item.ContentDetails?.Playlists != null && item.ContentDetails.Playlists.Any())
                    {
                        var playlists = new List<string>();
                        foreach (var playlist in item.ContentDetails.Playlists)
                        {
                            var destPlaylist = destPlaylists.FirstOrDefault(
                                p => p.OriginalPlaylistId == playlist);
                            if (destPlaylist != null)
                            {
                                playlists.Add(destPlaylist.PlaylistId);
                            }
                            else
                            {
                                playlists.Add(playlist);
                            }
                        }

                        item.ContentDetails.Playlists = playlists;
                    }

                    toUpload.Add(item);
                }

                await this.YoutubeProvider.UploadSections(destChannelId, toUpload);
            }
            catch (Exception exc)
            {
                this.Logger.LogError(exc.Message);
            }
        }

        #endregion

        #region subscriptions

        private async Task TransferSubscriptions(string sourceChannelId, string destChannelId)
        {
            try
            {
                var source = await this.YoutubeProvider.GetSubscriptions(sourceChannelId);
                var dest = await this.YoutubeProvider.GetSubscriptions(destChannelId);

                // skip existing items
                var toUpload = new List<Subscription>();
                foreach (var item in source
                    .Where(s => s.Snippet?.ResourceId != null))
                {
                    if (dest.Any(d =>
                        item.Snippet.ResourceId.ChannelId == d.Snippet.ResourceId.ChannelId))
                    {
                        continue;
                    }

                    toUpload.Add(item);
                }

                await this.YoutubeProvider.UploadSubscriptions(
                    destChannelId,
                    toUpload
                        .OrderBy(c => c.Snippet.PublishedAt).ToList());
            }
            catch (Exception exc)
            {
                this.Logger.LogError(exc.Message);
            }
        }

        #endregion

        #region comments

        private async Task TransferComments(string sourceChannelId, string destChannelId)
        {
            try
            {
                var source = await this.YoutubeProvider.GetComments(sourceChannelId);
                var dest = await this.YoutubeProvider.GetComments(destChannelId);

                var toUpload = new List<CommentThread>();
                foreach (var item in source
                    .Where(c => c.Snippet?.TopLevelComment?.Snippet != null))
                {
                    // skip existing items
                    if (dest.Any(d =>
                        item.Snippet.TopLevelComment.Snippet.TextDisplay == d.Snippet.TopLevelComment.Snippet.TextDisplay))
                    {
                        continue;
                    }

                    toUpload.Add(item);
                }

                await this.YoutubeProvider.UploadComments(
                    destChannelId,
                    toUpload
                        .OrderBy(c => c.Snippet.TopLevelComment.Snippet.PublishedAt).ToList());
            }
            catch (Exception exc)
            {
                this.Logger.LogError(exc.Message);
            }
        }

        #endregion

        #region metadata

        private async Task TransferMetadata(string sourceChannelId, string destChannelId)
        {
            try
            {
                var source = await this.YoutubeProvider.GetChannel(sourceChannelId);

                var iconFilePath = await this.YoutubeProvider.DownloadIcon(source, this.outputFolder);
                this.Logger.LogTrace($"Icon downloaded to [{iconFilePath}].");

                var destVideos = await this.videosService.GetTransferVideos(sourceChannelId, destChannelId);
                var unsubscribedTrailer = destVideos.FirstOrDefault(v => 
                    v.OriginalVideoId == source.BrandingSettings.Channel.UnsubscribedTrailer);
                source.BrandingSettings.Channel.UnsubscribedTrailer = unsubscribedTrailer != null ? 
                    unsubscribedTrailer.VideoId : string.Empty;

                await this.YoutubeProvider.UpdateMetadata(destChannelId, source);
                await this.channelsService.AddOrUpdate(sourceChannelId, destChannelId, source);
            }
            catch (Exception exc)
            {
                this.Logger.LogError(exc.Message);
            }
        }

        #endregion
    }
}