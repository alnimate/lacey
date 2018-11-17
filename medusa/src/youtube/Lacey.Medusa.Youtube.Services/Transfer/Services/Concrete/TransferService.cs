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
            // transfer channel metadata
            var sourceChannel = await this.youtubeProvider.GetChannel(sourceChannelId);
            await this.youtubeProvider.UpdateChannelMetadata(destChannelId, sourceChannel);

            // transfer channel comments
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
            await this.youtubeProvider.UploadChannelComments(
                destChannelId, 
                commentsList
                    .OrderBy(c => c.Snippet.TopLevelComment.Snippet.PublishedAt).ToList());

            // transfer videos
            var sourceVideos = await this.youtubeProvider.GetChannelVideos(sourceChannelId);
            var destVideos = await this.youtubeProvider.GetChannelVideos(destChannelId);

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
                    await this.youtubeProvider.UploadVideo(
                        destChannelId,
                        video, 
                        filePath);
                }
                finally
                {
                    File.Delete(filePath);
                }
            }
        }
    }
}