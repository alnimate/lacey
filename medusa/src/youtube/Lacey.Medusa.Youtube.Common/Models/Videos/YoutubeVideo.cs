using System;
using Lacey.Medusa.Youtube.Common.Models.Common;

namespace Lacey.Medusa.Youtube.Common.Models.Videos
{
    public sealed class YoutubeVideo
    {
        public YoutubeVideo(
            string videoId,
            string title,
            string description,
            DateTime? publishedAt, 
            YoutubeThumbnails thumbnails)
        {
            
            VideoId = videoId;
            Title = title;
            Description = description;
            PublishedAt = publishedAt;
            Thumbnails = thumbnails;
        }

        public string VideoId { get; }

        public string Title { get; }

        public string Description { get; }

        public DateTime? PublishedAt { get; }

        public YoutubeThumbnails Thumbnails { get; }
    }
}