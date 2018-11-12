namespace Lacey.Medusa.Youtube.Common.Models.Common
{
    public sealed class YoutubeChannelInfo
    {
        public YoutubeChannelInfo(
            string channelId, 
            string title)
        {
            ChannelId = channelId;
            Title = title;
        }

        public string ChannelId { get; }

        public string Title { get; }
    }
}