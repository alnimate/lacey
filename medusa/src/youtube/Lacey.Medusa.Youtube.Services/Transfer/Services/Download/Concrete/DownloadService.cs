using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Lacey.Medusa.Youtube.Common.Interfaces;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Download;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Download.Concrete
{
    public sealed class DownloadService : IDownloadService
    {
        private readonly IYoutubeChannelProvider channelProvider;

        private readonly IYoutubeVideosProvider videosProvider;

        private readonly IMapper mapper;

        public DownloadService(
            IYoutubeChannelProvider channelProvider,
            IYoutubeVideosProvider videosProvider,
            IMapper mapper)
        {
            this.channelProvider = channelProvider;
            this.mapper = mapper;
            this.videosProvider = videosProvider;
        }

        public async Task<DownloadChannel> DownloadChannel(string channelId)
        {
            var channel = await this.channelProvider.GetYoutubeChannel(channelId);
            var videos = await this.videosProvider.GetYoutubeVideos(channelId);

            return new DownloadChannel(
                this.mapper.Map<DownloadChannelInfo>(channel),
                this.mapper.Map<IEnumerable<DownloadVideo>>(videos));
        }
    }
}