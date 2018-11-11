using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Validation.Extensions;
using Lacey.Medusa.Youtube.Common.Interfaces;
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
            var destChannel = await this.channelProvider.GetYoutubeChannel(destChannelId);

            var validSourceVideos = sourceChannel.Videos.Items
                .ValidationFilter(out var invalidVideos);
            foreach (var invalidVideo in invalidVideos)
            {
                this.logger.LogTrace($"Video \"{invalidVideo.Title}\" skipped. {invalidVideo.ValidationResult}");
            }

            foreach (var video in validSourceVideos
                .OrderBy(v => v.PublishedAt))
            {
                if (destChannel.Videos.Items.Any(video.Equals))
                {
                    this.logger.LogTrace($"Video \"{video.Title}\" skipped. Video already exists.");
                    continue;
                }

                var videoFile = await this.downloadVideoProvider.DownloadVideo(video.VideoId);

                await this.uploadVideoProvider.UploadVideo(
                    destChannelId,
                    video,
                    videoFile.FilePath);
            }
        }
    }
}