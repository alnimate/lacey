using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Api.Services;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete
{
    public sealed class TransferService : ITransferService
    {
        private readonly IYoutubeProvider youtubeProvider;

        private readonly ILogger logger;

        public TransferService(
            IYoutubeProvider youtubeProvider, 
            ILogger<TransferService> logger)
        {
            this.youtubeProvider = youtubeProvider;
            this.logger = logger;
        }

        public async Task TransferChannel(string sourceChannelId, string destChannelId)
        {
            await this.TransferChannelMetadata(sourceChannelId, destChannelId);

            await this.TransferSubscriptions(sourceChannelId, destChannelId);

            await this.TransferPlaylists(sourceChannelId, destChannelId);

            await this.TransferChannelComments(sourceChannelId, destChannelId);

//            await this.TransferVideos(sourceChannelId, destChannelId);
        }

        private async Task<Channel> TransferChannelMetadata(string sourceChannelId, string destChannelId)
        {
            Channel uploaded = null;
            try
            {
                var source = await this.youtubeProvider.GetChannel(sourceChannelId);
                uploaded = await this.youtubeProvider.UpdateChannelMetadata(destChannelId, source);
            }
            catch (Exception exc)
            {
                this.logger.LogError(exc.Message);
            }

            return uploaded;
        }

        private async Task<IList<Subscription>> TransferSubscriptions(string sourceChannelId, string destChannelId)
        {
            IList<Subscription> uploaded = new List<Subscription>();
            try
            {
                var source = await this.youtubeProvider.GetSubscriptions(sourceChannelId);
                var dest = await this.youtubeProvider.GetSubscriptions(destChannelId);

                // skip existing items
                var toUpload = new List<Subscription>();
                foreach (var item in source)
                {
                    if (dest.Any(d =>
                        item.Snippet.ResourceId.ChannelId == d.Snippet.ResourceId.ChannelId))
                    {
                        continue;
                    }

                    toUpload.Add(item);
                }

                uploaded = await this.youtubeProvider.UploadSubscriptions(
                    destChannelId,
                    toUpload
                        .OrderBy(c => c.Snippet.PublishedAt).ToList());
            }
            catch (Exception exc)
            {
                this.logger.LogError(exc.Message);
            }

            return uploaded;
        }

        private async Task<IList<Playlist>> TransferPlaylists(string sourceChannelId, string destChannelId)
        {
            IList<Playlist> uploaded = new List<Playlist>();
            try
            {
                var source = await this.youtubeProvider.GetPlaylists(sourceChannelId);
                var dest = await this.youtubeProvider.GetPlaylists(destChannelId);

                // skip existing items
                var toUpload = new List<Playlist>();
                foreach (var item in source.Take(1))
                {
                    if (dest.Any(d =>
                        item.Snippet.Title == d.Snippet.Title &&
                        item.Snippet.Description == d.Snippet.Description))
                    {
                        continue;
                    }

                    toUpload.Add(item);
                }

                uploaded = await this.youtubeProvider.UploadPlaylists(
                    destChannelId,
                    toUpload
                        .OrderBy(c => c.Snippet.PublishedAt).ToList());
            }
            catch (Exception exc)
            {
                this.logger.LogError(exc.Message);
            }

            return uploaded;
        }

        private async Task<IList<CommentThread>> TransferChannelComments(string sourceChannelId, string destChannelId)
        {
            IList<CommentThread> uploaded = new List<CommentThread>();
            try
            {
                var source = await this.youtubeProvider.GetChannelComments(sourceChannelId);
                var dest = await this.youtubeProvider.GetChannelComments(destChannelId);

                var toUpload = new List<CommentThread>();
                foreach (var item in source)
                {
                    // skip existing items
                    if (dest.Any(d =>
                        item.Snippet.TopLevelComment.Snippet.TextDisplay == d.Snippet.TopLevelComment.Snippet.TextDisplay))
                    {
                        continue;
                    }

                    toUpload.Add(item);
                }

                uploaded = await this.youtubeProvider.UploadChannelComments(
                    destChannelId,
                    toUpload
                        .OrderBy(c => c.Snippet.TopLevelComment.Snippet.PublishedAt).ToList());
            }
            catch (Exception exc)
            {
                this.logger.LogError(exc.Message);
            }

            return uploaded;
        }

        private async Task<IList<Video>> TransferVideos(string sourceChannelId, string destChannelId)
        {
            var source = await this.youtubeProvider.GetChannelVideos(sourceChannelId);
            var dest = await this.youtubeProvider.GetChannelVideos(destChannelId);

            var uploaded = new List<Video>();
            foreach (var item in source
                .OrderBy(v => v.Snippet.PublishedAt))
            {
                // skip existing items
                if (dest.Any(d =>
                    item.Snippet.Title == d.Snippet.Title &&
                    item.ContentDetails.Duration == d.ContentDetails.Duration))
                {
                    this.logger.LogTrace($"Video [{item.Snippet.Title}] skipped. Video already exists.");
                    continue;
                }

                var filePath = await this.youtubeProvider.DownloadVideo(item.Id);
                try
                {
                    uploaded.Add(await this.youtubeProvider.UploadVideo(
                        destChannelId,
                        item,
                        filePath));
                }
                catch (Exception exc)
                {
                    this.logger.LogError(exc.Message);
                }
                finally
                {
                    File.Delete(filePath);
                }
            }

            return uploaded;
        }
    }
}