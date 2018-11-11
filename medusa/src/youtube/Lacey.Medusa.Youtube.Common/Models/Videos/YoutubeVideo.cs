using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lacey.Medusa.Common.Validation.Validation;
using Lacey.Medusa.Youtube.Common.Models.Common;

namespace Lacey.Medusa.Youtube.Common.Models.Videos
{
    public sealed class YoutubeVideo : ValidatableModel, IEquatable<YoutubeVideo>
    {
        public YoutubeVideo(
            string videoId,
            string title,
            string description,
            DateTime? publishedAt, 
            YoutubeThumbnails thumbnails, 
            IEnumerable<string> tags, 
            TimeSpan duration)
        {
            
            VideoId = videoId;
            Title = title;
            Description = description;
            PublishedAt = publishedAt;
            Thumbnails = thumbnails;
            Tags = tags;
            Duration = duration;
        }

        [Required]
        public string VideoId { get; }

        [Required]
        public string Title { get; }

        public string Description { get; }

        public DateTime? PublishedAt { get; }

        public YoutubeThumbnails Thumbnails { get; }

        public IEnumerable<string> Tags { get; }

        public TimeSpan Duration { get; }

        public bool Equals(YoutubeVideo other)
        {
            return this.Title.Trim().ToLower() == other.Title.Trim().ToLower() &&
                   this.Duration == other.Duration;
        }
    }
}