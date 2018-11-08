using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Common.Interfaces;
using Lacey.Medusa.Youtube.Common.Models;
using Lacey.Medusa.Youtube.Scrap.Services.Common;

namespace Lacey.Medusa.Youtube.Scrap.Services.Channels
{
    public sealed class YoutubeChannelScrapProvider : YoutubeScrapService, IYoutubeChannelProvider
    {

        public async Task<YoutubeChannel> GetYoutubeChannel(string channelId)
        {
            var channel = await this.Youtube.GetChannelAsync(channelId);

            return new YoutubeChannel(
                new YoutubeChannelInfo(channel.Id, channel.Title, null),
                new List<YoutubeVideo>());
        }
    }
}