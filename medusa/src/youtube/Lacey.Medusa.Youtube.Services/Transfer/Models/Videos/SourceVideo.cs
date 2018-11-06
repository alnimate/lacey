using System;

namespace Lacey.Medusa.Youtube.Services.Transfer.Models.Videos
{
    public sealed class SourceVideo
    {
        public SourceVideo(
            string videoId,
            string title,
            string description,
            DateTime? publishedAt,
            string channelId)
        {
            
            VideoId = videoId;
            Title = title;
            Description = description;
            PublishedAt = publishedAt;
            ChannelId = channelId;
        }

        public string VideoId { get; }

        public string Title { get; }

        public string Description { get; }

        public DateTime? PublishedAt { get; }

        public string ChannelId { get; }
    }
}