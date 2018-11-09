using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Common.Interfaces;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete
{
    public sealed class TransferService : ITransferService
    {
        private readonly IYoutubeChannelProvider channelProvider;

        public TransferService(IYoutubeChannelProvider channelProvider)
        {
            this.channelProvider = channelProvider;
        }

        public async Task TransferChannel(string sourceChannelId, string destChannelId)
        {
            var channel = await this.channelProvider.GetYoutubeChannel(sourceChannelId);
        }
    }
}