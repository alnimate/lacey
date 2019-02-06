using System;
using System.Collections.Generic;
using Lacey.Medusa.Common.Domain.Entities;
using Lacey.Medusa.Common.Domain.Interfaces;

namespace Lacey.Medusa.Instagram.Domain.Entities
{
    public class ChannelEntity : IntIdEntity, INamedEntity
    {
        public string ChannelId { get; set; }

        public string OriginalChannelId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? PublishedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<MediaEntity> Medias { get; set; }
    }
}