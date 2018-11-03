using System;
using System.ComponentModel.DataAnnotations;
using Lacey.Medusa.Common.DataAnnotations.Attributes.Data;

namespace Lacey.Medusa.Youtube.Services.Youtube.Models.Videos.Overviews
{
    public sealed class VideoOverview
    {
        public VideoOverview(
            int id,
            string videoId,
            string description,
            DateTime publishedAt,
            int channelId)
        {
            this.Id = id;
            VideoId = videoId;
            Description = description;
            PublishedAt = publishedAt;
            ChannelId = channelId;
        }

        [IntId]
        public int Id { get; }

        [Required]
        [MaxLength(20)]
        public string VideoId { get; }

        [Required]
        [MaxLength(100)]
        public string Description { get; }

        public DateTime PublishedAt { get; }

        [IntId]
        public int ChannelId { get; }
    }
}