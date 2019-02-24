using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Cli.Utils;
using Lacey.Medusa.Common.Extensions.Extensions;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Api.Extensions;
using Lacey.Medusa.Youtube.Api.Services;
using Lacey.Medusa.Youtube.Domain.Entities;
using Lacey.Medusa.Youtube.Services.Common.Services;
using Lacey.Medusa.Youtube.Services.Transfer.Extensions;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete
{
    public sealed class TransferService : YoutubeApiService, ITransferService
    {
        #region Fields/Constructors

        private readonly IChannelsService channelsService;

        private readonly IVideosService videosService;

        private readonly IPlaylistsService playlistsService;

        private readonly string outputFolder;

        private readonly IVideoObfuscateService videoObfuscateService;

        private readonly int threshold;

        public TransferService(
            IYoutubeProvider youtubeProvider,
            ILogger<TransferService> logger,
            string outputFolder,
            IChannelsService channelsService,
            IVideosService videosService,
            IPlaylistsService playlistsService, 
            IVideoObfuscateService videoObfuscateService, 
            int threshold) : base(youtubeProvider, logger)
        {
            this.outputFolder = outputFolder;
            this.channelsService = channelsService;
            this.videosService = videosService;
            this.playlistsService = playlistsService;
            this.videoObfuscateService = videoObfuscateService;
            this.threshold = threshold;
        }

        #endregion

        #region update videos

        public async Task UpdateVideos(
            string sourceChannelId,
            string destChannelId,
            Dictionary<string, string> replacements)
        {
            ChannelEntity channel;
            IReadOnlyList<VideoEntity> videos;
            IReadOnlyList<Video> sourceVideos;
            IReadOnlyList<Video> destVideos;

            while (true)
            {
                try
                {
                    channel = await this.channelsService.GetChannelMetadata(destChannelId);
                    videos = await this.videosService.GetChannelVideos(destChannelId);

                    sourceVideos = await this.YoutubeProvider.GetVideosLast(sourceChannelId);
                    destVideos = await this.YoutubeProvider.GetVideos(destChannelId);
                    break;
                }
                catch (Exception e)
                {
                    this.Logger.LogError(e.Message);
                    ConsoleUtils.WaitSec(5 * 60);
                }
            }

            var uploadedSourceVideos = new List<Video>();
            foreach (var sourceVideo in sourceVideos
                .Where(v => v.Snippet != null)
                .OrderBy(v => v.Snippet.PublishedAt))
            {
                if (sourceVideo.Id != "zfECyZ77VBo")
                {
                    continue;
                }

                if (sourceVideo.IsObsoleted(this.threshold))
                {
                    continue;
                }

                // skip existing items
                if ((videos != null &&
                     videos.Any(u => u.OriginalVideoId == sourceVideo.Id))
                    || destVideos.Any(d =>
                    sourceVideo.Snippet.Title == d.Snippet.Title &&
                    sourceVideo.Snippet.Description == d.Snippet.Description))
                {
                    continue;
                }

                string filePath = null;
                string obfuscatedFilePath = null;
                try
                {
                    var name = sourceVideo.Snippet.Title;
                    this.Logger.LogTrace($"Downloading \"{name}\"...");
                    filePath = await this.YoutubeProvider.DownloadVideo(sourceVideo.Id, this.outputFolder);
                    this.Logger.LogTrace($"\"{name}\" => \"{filePath}\"");

                    this.Logger.LogTrace($"Obfuscating \"{name}\"...");
                    obfuscatedFilePath = Path.Combine(this.outputFolder, $"{Guid.NewGuid()}.mp4");
                    this.videoObfuscateService.Obfuscate(filePath, obfuscatedFilePath);
                    this.Logger.LogTrace($"\"{name}\" => \"{filePath}\"");

                    this.Logger.LogTrace($"Uploading \"{name}\"...");
                    var uploadedVideo = await this.YoutubeProvider.UploadVideo(
                        destChannelId,
                        sourceVideo.ReplaceDescription(replacements),
                        obfuscatedFilePath);
                    if (uploadedVideo == null)
                    {
                        continue;
                    }
                    uploadedSourceVideos.Add(sourceVideo);
                    this.Logger.LogTrace($"\"{name}\" uploaded.");

                    this.Logger.LogTrace($"Saving \"{name}\" to the database...");
                    await this.videosService.Add(channel.Id, sourceVideo.Id, uploadedVideo);
                    this.Logger.LogTrace($"\"{name}\" saved.");
                }
                catch (Exception exc)
                {
                    this.Logger.LogError(exc.Message);
                    ConsoleUtils.WaitSec(60);
                }
                finally
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    if (File.Exists(obfuscatedFilePath))
                    {
                        File.Delete(obfuscatedFilePath);
                    }
                }
            }

            if (uploadedSourceVideos.Any())
            {
                ConsoleUtils.WaitSec(20 * 60);
                await this.SetThumbnails(sourceChannelId, destChannelId, true, uploadedSourceVideos);
                ConsoleUtils.WaitSec(60);
                await this.TransferPlaylists(sourceChannelId, destChannelId, true);
                await this.TransferMetadata(sourceChannelId, destChannelId, false, replacements);
            }
        }

        #endregion

        #region Thumbnails

        public async Task SetThumbnailsLast(string sourceChannelId, string destChannelId)
        {
            await this.SetThumbnails(sourceChannelId, destChannelId, true);
        }

        public async Task SetThumbnails(string sourceChannelId, string destChannelId)
        {
            await this.SetThumbnails(sourceChannelId, destChannelId, false);
        }

        private async Task SetThumbnails(
            string sourceChannelId, 
            string destChannelId,
            bool onlyLast,
            IReadOnlyList<Video> source = null)
        {
            IReadOnlyList<Video> sourceVideos;
            if (source != null)
            {
                sourceVideos = source;
            }
            else
            {
                sourceVideos = onlyLast ? await this.YoutubeProvider.GetVideosLast(sourceChannelId) :
                    await this.YoutubeProvider.GetVideos(sourceChannelId);
            }

            var destVideos = await this.videosService.GetChannelVideos(destChannelId);
            foreach (var destVideo in destVideos)
            {
                var sourceVideo = sourceVideos.FirstOrDefault(s => s.Id == destVideo.OriginalVideoId);
                if (sourceVideo == null)
                {
                    continue;
                }

                if (onlyLast && destVideo.IsObsoleted(this.threshold))
                {
                    continue;
                }

                try
                {
                    this.Logger.LogTrace($"Uploading thumbnail for [\"{sourceVideo.Snippet.Title}\"]...");
                    await this.YoutubeProvider.UploadThumbnail(
                        destVideo.VideoId,
                        sourceVideo.Snippet.Thumbnails.GetMaxResUrl());
                    this.Logger.LogTrace($"Thumbnail uploaded.");
                }
                catch (Exception exc)
                {
                    this.Logger.LogError(exc.Message);
                }
            }
        }

        #endregion

        #region playlists

        public async Task TransferPlaylists(string sourceChannelId, string destChannelId, bool onlyLast)
        {
            try
            {
                var sourcePlaylists = await this.YoutubeProvider.GetPlaylists(sourceChannelId);
                var destPlaylists = await this.YoutubeProvider.GetPlaylists(destChannelId);
                var localChannel = await this.channelsService.GetChannelMetadata(destChannelId);
                var localVideos = await this.videosService.GetTransferVideos(sourceChannelId, destChannelId);
                var localPlaylists = await this.playlistsService.GetChannelPlaylists(destChannelId);

                // skip existing items
                foreach (var sourcePlaylist in sourcePlaylists
                    .Where(p => p.Snippet != null)
                    .OrderBy(p => p.Snippet.PublishedAt))
                {
                    var destPlaylist = destPlaylists.FirstOrDefault(d =>
                        sourcePlaylist.Snippet.Title == d.Snippet.Title);

                    PlaylistEntity localPlaylist;
                    if (destPlaylist == null)
                    {
                        destPlaylist = await this.YoutubeProvider.UploadPlaylist(destChannelId, sourcePlaylist);
                        var localPlaylistId = await this.playlistsService.Add(localChannel.Id, sourcePlaylist.Id, destPlaylist);
                        localPlaylist = await this.playlistsService.GetPlaylist(localPlaylistId);
                    }
                    else
                    {
                        localPlaylist = localPlaylists.FirstOrDefault(p => p.PlaylistId == destPlaylist.Id);
                    }

                    if (localPlaylist == null)
                    {
                        continue;
                    }

                    var localPlaylistVideos =
                        await this.playlistsService.GetPlaylistVideos(localPlaylist.Id);

                    // insert playlist items
                    var sourceItems = await this.YoutubeProvider.GetPlaylistItems(sourcePlaylist.Id);
                    foreach (var sourceItem in sourceItems)
                    {
                        if (sourceItem.Snippet.ResourceId == null)
                        {
                            continue;
                        }

                        var localVideo = localVideos.FirstOrDefault(
                            l => l.OriginalVideoId == sourceItem.Snippet.ResourceId.VideoId);

                        if (localVideo != null)
                        {
                            // if we already have this video in playlist
                            if (localPlaylistVideos.Any(v => v.VideoId == localVideo.Id))
                            {
                                continue;
                            }

                            sourceItem.Snippet.ResourceId.VideoId = localVideo.VideoId;
                        }

                        // skip old videos
                        if (sourceItem.Snippet.PublishedAt == null || 
                            onlyLast && sourceItem.IsObsoleted(this.threshold))
                        {
                            continue;
                        }

                        await this.YoutubeProvider.UploadPlaylistItem(destChannelId, destPlaylist.Id, sourceItem);

                        if (localVideo != null)
                        {
                            await this.playlistsService.AddVideoToPlaylist(destPlaylist.Id, localVideo.VideoId);
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

        #region Full Transfer

        public async Task TransferChannel(string sourceChannelId, string destChannelId)
        {
//            await this.TransferComments(sourceChannelId, destChannelId);

            await this.TransferMetadata(sourceChannelId, destChannelId, true);

            await this.TransferVideos(sourceChannelId, destChannelId);

            await this.TransferPlaylists(sourceChannelId, destChannelId, false);

            await this.TransferSections(sourceChannelId, destChannelId);

            await this.TransferSubscriptions(sourceChannelId, destChannelId);
        }

        #endregion

        #region transfer videos

        public async Task UpdateInstagram(string channelId, string originalInstagram, string newInstagram)
        {
            var list = new List<Video>();
            var videos = await this.YoutubeProvider.GetVideos(channelId);
            list.AddRange(videos);

            var localVideos = await this.videosService.GetChannelVideos(channelId);
            var ids = new List<string>();
            foreach (var localVideo in localVideos)
            {
                if (localVideo.Description.Contains(originalInstagram, StringComparison.InvariantCultureIgnoreCase))
                {
                    ids.Add(localVideo.VideoId);
                }
            }
            var videos1 = await this.YoutubeProvider.GetVideos(ids);
            foreach (var video1 in videos1)
            {
                if (list.All(v => v.Id != video1.Id))
                {
                    list.Add(video1);
                }
            }

            foreach (var video in list
                .Where(v => v.Snippet != null)
                .OrderByDescending(v => v.Snippet.PublishedAt))
            {
                var description = video.Snippet.Description;
                if (description == null)
                {
                    continue;
                }

                if (!video.Snippet.Description.Contains(originalInstagram, StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                this.Logger.LogTrace($"Updating \"{video.Snippet.Title}\" description.");
                var updatedvideo = await this.YoutubeProvider.UpdateVideoDescription(
                    video, originalInstagram, newInstagram);

                if (updatedvideo == null)
                {
                    continue;
                }

                await this.videosService.UpdateDescription(video.Id, updatedvideo.Snippet.Description);
                this.Logger.LogTrace($"Updated \"{video.Snippet.Title}\".");
            }
        }

        public async Task TransferVideos(string sourceChannelId, string destChannelId)
        {
            var sourceVideos = await this.YoutubeProvider.GetVideos(sourceChannelId);
            var dest = await this.YoutubeProvider.GetVideos(destChannelId);
            var destChannel = await this.channelsService.GetChannelMetadata(destChannelId);
            var uploadedVideos = await this.videosService.GetChannelVideos(destChannelId);

            foreach (var sourceVideo in sourceVideos
                .Where(v => v.Snippet != null)
                .OrderBy(v => v.Snippet.PublishedAt))
            {
                // skip existing items
                if ((uploadedVideos != null && 
                     uploadedVideos.Any(u => u.OriginalVideoId == sourceVideo.Id))                   
                    || dest.Any(d =>
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

        #region sections

        public async Task TransferSections(string sourceChannelId, string destChannelId)
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

        public async Task TransferSubscriptions(string sourceChannelId, string destChannelId)
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

        public async Task TransferComments(string sourceChannelId, string destChannelId)
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

        public async Task TransferMetadata(
            string sourceChannelId, 
            string destChannelId, 
            bool downloadIcon = false,
            Dictionary<string, string> replacements = null)
        {
            try
            {
                var sourceChannel = await this.YoutubeProvider.GetChannel(sourceChannelId);

                if (downloadIcon)
                {
                    var iconFilePath = await this.YoutubeProvider.DownloadIcon(sourceChannel, this.outputFolder);
                    this.Logger.LogTrace($"Icon downloaded to [{iconFilePath}].");
                }

                if (replacements != null && replacements.Any())
                {
                    sourceChannel.BrandingSettings.Channel.Description =
                        sourceChannel.BrandingSettings.Channel.Description.ReplaceWholeWords(replacements);
                }

                var destVideos = await this.videosService.GetTransferVideos(sourceChannelId, destChannelId);
                var trailer = destVideos.FirstOrDefault(v =>
                    v.OriginalVideoId == sourceChannel.BrandingSettings.Channel.UnsubscribedTrailer);

                if (trailer != null)
                {
                    var destChannel = await this.YoutubeProvider.GetChannel(destChannelId);
                    if (destChannel != null)
                    {
                        if (destChannel.BrandingSettings.Channel.UnsubscribedTrailer ==
                            trailer.VideoId)
                        {
                            return;
                        }
                    }
                }

                sourceChannel.BrandingSettings.Channel.UnsubscribedTrailer = trailer != null ? 
                    trailer.VideoId : string.Empty;

                await this.YoutubeProvider.UpdateMetadata(destChannelId, sourceChannel);
                await this.channelsService.AddOrUpdate(sourceChannelId, destChannelId, sourceChannel);
            }
            catch (Exception exc)
            {
                this.Logger.LogError(exc.Message);
            }
        }

        #endregion
    }
}