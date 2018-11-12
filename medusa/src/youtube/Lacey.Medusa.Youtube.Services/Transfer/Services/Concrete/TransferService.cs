using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Validation.Extensions;
using Lacey.Medusa.Youtube.Common.Services;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete
{
    public sealed class TransferService : ITransferService
    {
        private readonly IYoutubeChannelProvider channelProvider;

        private readonly IYoutubeDownloadVideoProvider downloadVideoProvider;

        private readonly IYoutubeUploadVideoProvider uploadVideoProvider;

        private readonly ILogger logger;

        public TransferService(
            IYoutubeChannelProvider channelProvider, 
            IYoutubeDownloadVideoProvider downloadVideoProvider, 
            IYoutubeUploadVideoProvider uploadVideoProvider, 
            ILogger<TransferService> logger)
        {
            this.channelProvider = channelProvider;
            this.downloadVideoProvider = downloadVideoProvider;
            this.uploadVideoProvider = uploadVideoProvider;
            this.logger = logger;
        }

        public async Task TransferChannel(string sourceChannelId, string destChannelId)
        {
            var sourceChannel = await this.channelProvider.GetYoutubeChannel(sourceChannelId);
            var destVideos = await this.channelProvider.GetChannelVideos(destChannelId);

            var validSourceVideos = sourceChannel.Videos.Items
                .ValidationFilter(out var invalidVideos);
            foreach (var invalidVideo in invalidVideos)
            {
                this.logger.LogTrace($"Video \"{invalidVideo.Title}\" skipped. {invalidVideo.ValidationResult}");
            }

            foreach (var video in validSourceVideos
                .OrderBy(v => v.PublishedAt))
            {
                if (destVideos.Items.Any(video.Equals))
                {
                    this.logger.LogTrace($"Video \"{video.Title}\" skipped. Video already exists.");
                    continue;
                }

                var videoFile = await this.downloadVideoProvider.DownloadVideo(video.VideoId);

                try
                {
                    await this.uploadVideoProvider.UploadVideo(
                        destChannelId,
                        video,
                        videoFile.FilePath);
                }
                finally
                {
                    this.logger.LogTrace("Deleting temp files...");
                    File.Delete(videoFile.FilePath);
                }
            }
        }
    }
}