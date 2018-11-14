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
            var sourceVideos = await this.youtubeProvider.GetChannelVideos(sourceChannelId);
            var destVideos = await this.youtubeProvider.GetChannelVideos(destChannelId);

            foreach (var video in sourceVideos
                .OrderBy(v => v.Snippet.PublishedAt))
            {
                if (destVideos.Any(d => video.Snippet.Title == d.Snippet.Title))
                {
                    this.logger.LogTrace($"Video \"{video.Snippet.Title}\" skipped. Video already exists.");
                    continue;
                }

                var filePath = await this.youtubeProvider.DownloadVideo(video.Id.VideoId);
                try
                {
                    await this.youtubeProvider.UploadVideo(
                        destChannelId,
                        new Video
                        {
                            Snippet = new VideoSnippet
                            {
                                Title = video.Snippet.Title,
                                Description = video.Snippet.Description,
                                CategoryId = "22", // See https://developers.google.com/youtube/v3/docs/videoCategories/list
                            },
                            Status = new VideoStatus
                            {
                                PrivacyStatus = "public"
                            }
                        }, 
                        filePath);
                }
                finally
                {
                    this.logger.LogTrace("Deleting temp files...");
                    File.Delete(filePath);
                }
            }
        }
    }
}