using System;

namespace Lacey.Medusa.Youtube.Services.Transfer.Models.Download
{
    public sealed class DownloadVideo
    {
        public DownloadVideo(
            string videoId,
            string title,
            string description,
            DateTime? publishedAt)
        {
            
            VideoId = videoId;
            Title = title;
            Description = description;
            PublishedAt = publishedAt;
        }

        public string VideoId { get; }

        public string Title { get; }

        public string Description { get; }

        public DateTime? PublishedAt { get; }
    }
}