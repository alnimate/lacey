using System;
using Lacey.Medusa.Common.Domain.Entities;
using Lacey.Medusa.Common.Domain.Interfaces;

namespace Lacey.Medusa.Instagram.Domain.Entities
{
    public class MediaEntity : IntIdEntity, INamedEntity
    {
        public string MediaId { get; set; }

        public string OriginalMediaId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? PublishedAt { get; set; }

        public int ChannelId { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ChannelEntity Channel { get; set; }
    }
}