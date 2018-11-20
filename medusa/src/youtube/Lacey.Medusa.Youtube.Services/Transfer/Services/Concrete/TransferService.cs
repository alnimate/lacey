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
//            await this.TransferChannelMetadata(sourceChannelId, destChannelId);                

            await this.TransferPlaylists(sourceChannelId, destChannelId);

//            await this.TransferChannelComments(sourceChannelId, destChannelId);

//            await this.TransferVideos(sourceChannelId, destChannelId);
        }

        private async Task<Channel> TransferChannelMetadata(string sourceChannelId, string destChannelId)
        {
            var sourceChannel = await this.youtubeProvider.GetChannel(sourceChannelId);
            return await this.youtubeProvider.UpdateChannelMetadata(destChannelId, sourceChannel);
        }

        private async Task<IList<Playlist>> TransferPlaylists(string sourceChannelId, string destChannelId)
        {
            var sourceChannelPlaylists = await this.youtubeProvider.GetPlaylists(sourceChannelId);
            var destChannelPlaylists = await this.youtubeProvider.GetPlaylists(destChannelId);

            // skip existing channel playlists
            var playlists = new List<Playlist>();
            var i = 0;
            foreach (var playlist in sourceChannelPlaylists)
            {
                if (i > 0)
                {
                    break;
                }

                if (destChannelPlaylists.Any(d =>
                    playlist.Snippet.Title == d.Snippet.Title &&
                    playlist.Snippet.Description == d.Snippet.Description))
                {
                    continue;
                }

                playlists.Add(playlist);
                i++;
            }

            return await this.youtubeProvider.UploadPlaylists(
                destChannelId,
                playlists
                    .OrderBy(c => c.Snippet.PublishedAt).ToList());
        }

        private async Task<IList<CommentThread>> TransferChannelComments(string sourceChannelId, string destChannelId)
        {
            var sourceChannelComments = await this.youtubeProvider.GetChannelComments(sourceChannelId);
            var destChannelComments = await this.youtubeProvider.GetChannelComments(destChannelId);
            // skip existing channel comments
            var commentsList = new List<CommentThread>();
            foreach (var comment in sourceChannelComments)
            {
                if (destChannelComments.Any(d =>
                    comment.Snippet.TopLevelComment.Snippet.TextDisplay == d.Snippet.TopLevelComment.Snippet.TextDisplay))
                {
                    continue;
                }

                commentsList.Add(comment);
            }

            return await this.youtubeProvider.UploadChannelComments(
                destChannelId,
                commentsList
                    .OrderBy(c => c.Snippet.TopLevelComment.Snippet.PublishedAt).ToList());
        }

        private async Task<IList<Video>> TransferVideos(string sourceChannelId, string destChannelId)
        {
            var sourceVideos = await this.youtubeProvider.GetChannelVideos(sourceChannelId);
            var destVideos = await this.youtubeProvider.GetChannelVideos(destChannelId);

            var transferredVideos = new List<Video>();
            foreach (var video in sourceVideos
                .OrderBy(v => v.Snippet.PublishedAt))
            {
                // skip existing videos
                if (destVideos.Any(d =>
                    video.Snippet.Title == d.Snippet.Title &&
                    video.ContentDetails.Duration == d.ContentDetails.Duration))
                {
                    this.logger.LogTrace($"Video [{video.Snippet.Title}] skipped. Video already exists.");
                    continue;
                }

                var filePath = await this.youtubeProvider.DownloadVideo(video.Id);
                try
                {
                    transferredVideos.Add(await this.youtubeProvider.UploadVideo(
                        destChannelId,
                        video,
                        filePath));
                }
                finally
                {
                    File.Delete(filePath);
                }
            }

            return transferredVideos;
        }
    }
}