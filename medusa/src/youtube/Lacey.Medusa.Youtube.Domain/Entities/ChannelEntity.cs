using System;
using System.Collections.Generic;
using Lacey.Medusa.Common.Domain.Entities;
using Lacey.Medusa.Common.Domain.Interfaces;

namespace Lacey.Medusa.Youtube.Domain.Entities
{
    public class ChannelEntity : IntIdEntity, INamedEntity
    {
        public string ChannelId { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<VideoEntity> Videos { get; set; }
    }
}