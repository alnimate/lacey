using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Common.Interfaces;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete
{
    public sealed class TransferService : ITransferService
    {
        private readonly IYoutubeChannelProvider channelProvider;

        private readonly IYoutubeDownloadVideoProvider downloadVideoProvider;

        private readonly IYoutubeUploadVideoProvider uploadVideoProvider;

        public TransferService(
            IYoutubeChannelProvider channelProvider, 
            IYoutubeDownloadVideoProvider downloadVideoProvider, 
            IYoutubeUploadVideoProvider uploadVideoProvider)
        {
            this.channelProvider = channelProvider;
            this.downloadVideoProvider = downloadVideoProvider;
            this.uploadVideoProvider = uploadVideoProvider;
        }

        public async Task TransferChannel(string sourceChannelId, string destChannelId)
        {
            var channel = await this.channelProvider.GetYoutubeChannel(sourceChannelId);

            var video = channel.Videos.Items.ToArray()[1];
            var videoFile = await this.downloadVideoProvider.DownloadVideo(video.VideoId);

            await this.uploadVideoProvider.UploadVideo(
                destChannelId,
                video,
                videoFile.FilePath);
        }
    }
}