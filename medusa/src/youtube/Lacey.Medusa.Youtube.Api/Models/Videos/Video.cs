using System;

namespace Lacey.Medusa.Youtube.Api.Models.Videos
{
    public sealed class Video
    {
        public Video(
            string videoId,
            string description,
            DateTime publishedAt,
            int channelId)
        {
            
            VideoId = videoId;
            Description = description;
            PublishedAt = publishedAt;
            ChannelId = channelId;
        }

        public string VideoId { get; }

        public string Description { get; }

        public DateTime PublishedAt { get; }

        public int ChannelId { get; }
    }
}