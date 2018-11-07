using System;
using System.ComponentModel.DataAnnotations;
using Lacey.Medusa.Common.DataAnnotations.Attributes.Data;

namespace Lacey.Medusa.Youtube.Services.Transfer.Models.Store
{
    public sealed class StoreVideo
    {
        public StoreVideo(
            string videoId,
            string title,
            string description,
            DateTime publishedAt,
            int channelId)
        {
            VideoId = videoId;
            Title = title;
            Description = description;
            PublishedAt = publishedAt;
            ChannelId = channelId;
        }

        [Required]
        [MaxLength(30)]
        public string VideoId { get; }

        [Required]
        [MaxLength(30)]
        public string Title { get; }

        public string Description { get; }

        public DateTime PublishedAt { get; }

        [IntId]
        public int ChannelId { get; }
    }
}