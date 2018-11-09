using Lacey.Medusa.Youtube.Common.Models.About;
using Lacey.Medusa.Youtube.Common.Models.Videos;

namespace Lacey.Medusa.Youtube.Common.Models.Common
{
    public sealed class YoutubeChannel
    {
        public YoutubeChannel(
            string channelId, 
            string title, 
            YoutubeVideos videos, 
            YoutubeAbout about)
        {
            ChannelId = channelId;
            Title = title;
            Videos = videos;
            About = about;
        }

        public string ChannelId { get; }

        public string Title { get; }

        public YoutubeVideos Videos { get; }

        public YoutubeAbout About { get; }
    }
}