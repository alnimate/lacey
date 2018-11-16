using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
            await this.youtubeProvider.UploadChannelComments(destChannelId, sourceChannelComments);

            // transfer videos
            var sourceVideos = await this.youtubeProvider.GetChannelVideos(sourceChannelId);
            var destVideos = await this.youtubeProvider.GetChannelVideos(destChannelId);

            foreach (var video in sourceVideos
                .OrderBy(v => v.Snippet.PublishedAt))
            {
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