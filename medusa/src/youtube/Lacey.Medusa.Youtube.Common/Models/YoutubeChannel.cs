namespace Lacey.Medusa.Youtube.Common.Models
{
    public sealed class YoutubeChannel
    {
        public YoutubeChannel(
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