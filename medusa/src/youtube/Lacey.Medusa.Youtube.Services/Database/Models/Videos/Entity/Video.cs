using System;
using System.ComponentModel.DataAnnotations;
using Lacey.Medusa.Common.DataAnnotations.Attributes.Data;
using Lacey.Medusa.Common.Services.Models.Business;

namespace Lacey.Medusa.Youtube.Services.Database.Models.Videos.Entity
{
    public sealed class Video: IntIdBusinessModel
    {
        public Video(
            int id,
            string videoId,
            string name,
            string description, 
            DateTime publishedAt, 
            int channelId)
            : base(id)
        {
            VideoId = videoId;
            Name = name;
            Description = description;
            PublishedAt = publishedAt;
            ChannelId = channelId;
        }

        [Required]
        [MaxLength(20)]
        public string VideoId { get; }

        [Required]
        [MaxLength(30)]
        public string Name { get; }

        [Required]
        [MaxLength(100)]
        public string Description { get; }

        public DateTime PublishedAt { get; }

        [IntId]
        public int ChannelId { get; }
    }
}