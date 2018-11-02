using System;
using System.Collections.Generic;
using Lacey.Medusa.Common.Domain.Entities;

namespace Lacey.Medusa.Youtube.Domain.Entities
{
    public class ChannelEntity : IntIdEntity
    {
        public string ChannelId { get; set; }

        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<VideoEntity> Videos { get; set; }
    }
}