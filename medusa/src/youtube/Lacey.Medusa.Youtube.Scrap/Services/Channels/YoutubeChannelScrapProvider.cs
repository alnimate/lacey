using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lacey.Medusa.Youtube.Common.Models.About;
using Lacey.Medusa.Youtube.Common.Models.Common;
using Lacey.Medusa.Youtube.Common.Models.Videos;
using Lacey.Medusa.Youtube.Common.Services;
using Lacey.Medusa.Youtube.Scrap.Services.Common;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Scrap.Services.Channels
{
    public sealed class YoutubeChannelScrapProvider : YoutubeScrapService, IYoutubeChannelProvider
    {
        public YoutubeChannelScrapProvider(
            IMapper mapper,
            ILogger<YoutubeChannelScrapProvider> logger) 
            : base(mapper, logger)
        {
        }

        public async Task<YoutubeChannel> GetYoutubeChannel(string channelId)
        {
            var channel = await this.Youtube.GetChannelAsync(channelId);
            var uploads = await this.Youtube.GetChannelUploadsAsync(channelId);

            var channelInfo = new YoutubeChannelInfo(channel.Id, channel.Title);
            var videos = new YoutubeVideos(
                this.Mapper.Map<IEnumerable<YoutubeVideo>>(uploads).ToArray());
            var about = new YoutubeAbout(null);

            return new YoutubeChannel(channelInfo,
                videos,
                about);
        }

        public async Task<YoutubeVideos> GetChannelVideos(string channelId)
        {
            var uploads = await this.Youtube.GetChannelUploadsAsync(channelId);

            return new YoutubeVideos(
                this.Mapper.Map<IEnumerable<YoutubeVideo>>(uploads).ToArray());
        }
    }
}