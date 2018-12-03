using System;
using System.Collections.Generic;
using Lacey.Medusa.Common.Domain.Entities;
using Lacey.Medusa.Common.Domain.Interfaces;

namespace Lacey.Medusa.Youtube.Domain.Entities
{
    public class VideoEntity : IntIdEntity, INamedEntity
    {
        public string VideoId { get; set; }

        public string OriginalVideoId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime PublishedAt { get; set; }

        public int ChannelId { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ChannelEntity Channel { get; set; }

        public virtual ICollection<PlaylistVideoEntity> PlaylistVideos { get; set; }
    }
}