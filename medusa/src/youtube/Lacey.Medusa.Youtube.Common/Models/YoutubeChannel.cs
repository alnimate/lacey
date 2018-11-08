using System.Collections.Generic;

namespace Lacey.Medusa.Youtube.Common.Models
{
    public sealed class YoutubeChannel
    {
        public YoutubeChannel(
            YoutubeChannelInfo channel, 
            IEnumerable<YoutubeVideo> videos)
        {
            Channel = channel;
            Videos = videos;
        }

        public YoutubeChannelInfo Channel { get; }

        public IEnumerable<YoutubeVideo> Videos { get; }
    }
}