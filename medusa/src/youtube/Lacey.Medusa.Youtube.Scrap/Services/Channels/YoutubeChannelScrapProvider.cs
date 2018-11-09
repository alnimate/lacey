using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lacey.Medusa.Youtube.Common.Interfaces;
using Lacey.Medusa.Youtube.Common.Models.About;
using Lacey.Medusa.Youtube.Common.Models.Common;
using Lacey.Medusa.Youtube.Common.Models.Videos;
using Lacey.Medusa.Youtube.Scrap.Services.Common;

namespace Lacey.Medusa.Youtube.Scrap.Services.Channels
{
    public sealed class YoutubeChannelScrapProvider : YoutubeScrapService, IYoutubeChannelProvider
    {
        public YoutubeChannelScrapProvider(IMapper mapper) : base(mapper)
        {
        }

        public async Task<YoutubeChannel> GetYoutubeChannel(string channelId)
        {
            var channel = await this.Youtube.GetChannelAsync(channelId);
            var uploads = await this.Youtube.GetChannelUploadsAsync(channelId);

            var videos = new YoutubeVideos(
                this.Mapper.Map<IEnumerable<YoutubeVideo>>(uploads).ToArray());

            var about = new YoutubeAbout(null);

            return new YoutubeChannel(
                channel.Id, 
                channel.Title,
                videos,
                about);
        }
    }
}