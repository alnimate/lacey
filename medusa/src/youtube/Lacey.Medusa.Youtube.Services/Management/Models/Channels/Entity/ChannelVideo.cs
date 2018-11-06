using System;
using System.ComponentModel.DataAnnotations;
using Lacey.Medusa.Common.DataAnnotations.Attributes.Data;
using Lacey.Medusa.Common.Services.Models.Business;

namespace Lacey.Medusa.Youtube.Services.Management.Models.Channels.Entity
{
    public sealed class ChannelVideo : IntIdBusinessModel
    {
        public ChannelVideo(
            int id,
            string videoId,
            string description,
            DateTime publishedAt,
            int channelId)
            : base(id)
        {
            VideoId = videoId;
            Description = description;
            PublishedAt = publishedAt;
            ChannelId = channelId;
        }

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