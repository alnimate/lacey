using System;
using Lacey.Medusa.Common.Domain.Entities;

namespace Lacey.Medusa.Youtube.Domain.Entities
{
    public class VideoEntity : IntIdEntity
    {
        public string VideoId { get; set; }

        public string Description { get; set; }

        public DateTime PublishedAt { get; set; }

        public int ChannelId { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ChannelEntity Channel { get; set; }
    }
}