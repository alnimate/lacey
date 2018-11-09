using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Common.Interfaces;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete
{
    public sealed class TransferService : ITransferService
    {
        private readonly IYoutubeChannelProvider channelProvider;

        private readonly IYoutubeDownloadVideoProvider downloadVideoProvider;

        public TransferService(
            IYoutubeChannelProvider channelProvider, 
            IYoutubeDownloadVideoProvider downloadVideoProvider)
        {
            this.channelProvider = channelProvider;
            this.downloadVideoProvider = downloadVideoProvider;
        }

        public async Task TransferChannel(string sourceChannelId, string destChannelId)
        {
            var channel = await this.channelProvider.GetYoutubeChannel(sourceChannelId);

            var videosId = channel.Videos.Items.ToArray()[1].VideoId;
            await this.downloadVideoProvider.DownloadVideo(videosId);
        }
    }
}