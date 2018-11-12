using Lacey.Medusa.Youtube.Common.Models.About;
using Lacey.Medusa.Youtube.Common.Models.Videos;

namespace Lacey.Medusa.Youtube.Common.Models.Common
{
    public sealed class YoutubeChannel
    {
        public YoutubeChannel(
            YoutubeChannelInfo channel, 
            YoutubeVideos videos, 
            YoutubeAbout about)
        {
            Channel = channel;
            Videos = videos;
            About = about;
        }

        public YoutubeChannelInfo Channel { get; }

        public YoutubeVideos Videos { get; }

        public YoutubeAbout About { get; }
    }
}