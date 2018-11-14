namespace Lacey.Medusa.Youtube.Common.Models.Common
{
    public sealed class YoutubeChannelInfo
    {
        public YoutubeChannelInfo(
            string channelId, 
            string title, 
            YoutubeThumbnails thumbnails)
        {
            ChannelId = channelId;
            Title = title;
            Thumbnails = thumbnails;
        }

        public string ChannelId { get; }

        public string Title { get; }

        public YoutubeThumbnails Thumbnails { get; }
    }
}