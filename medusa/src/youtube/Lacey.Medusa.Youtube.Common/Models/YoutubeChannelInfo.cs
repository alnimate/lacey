namespace Lacey.Medusa.Youtube.Common.Models
{
    public sealed class YoutubeChannelInfo
    {
        public YoutubeChannelInfo(
            string channelId, 
            string title, 
            string description)
        {
            ChannelId = channelId;
            Title = title;
            Description = description;
        }

        public string ChannelId { get; }

        public string Title { get; }

        public string Description { get; }
    }
}