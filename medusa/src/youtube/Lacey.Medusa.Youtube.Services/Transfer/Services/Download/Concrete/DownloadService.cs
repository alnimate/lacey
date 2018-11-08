using System.Threading.Tasks;
using AutoMapper;
using Lacey.Medusa.Youtube.Common.Interfaces;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Download;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Download.Concrete
{
    public sealed class DownloadService : IDownloadService
    {
        private readonly IYoutubeChannelProvider youtubeChannelProvider;

        private readonly IMapper mapper;

        public DownloadService(
            IYoutubeChannelProvider youtubeChannelProvider, 
            IMapper mapper)
        {
            this.youtubeChannelProvider = youtubeChannelProvider;
            this.mapper = mapper;
        }

        public async Task<DownloadChannel> DownloadChannel(string channelId)
        {
            var youtubeChannel = await this.youtubeChannelProvider.GetYoutubeChannel(channelId);

            return this.mapper.Map<DownloadChannel>(youtubeChannel);
        }
    }
}