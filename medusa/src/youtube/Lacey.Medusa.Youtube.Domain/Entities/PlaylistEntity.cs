using System;
using System.Collections.Generic;
using Lacey.Medusa.Common.Domain.Entities;
using Lacey.Medusa.Common.Domain.Interfaces;

namespace Lacey.Medusa.Youtube.Domain.Entities
{
    public class PlaylistEntity : IntIdEntity, INamedEntity
    {
        public string PlaylistId { get; set; }

        public string OriginalPlaylistId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime PublishedAt { get; set; }

        public int ChannelId { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ChannelEntity Channel { get; set; }

        public virtual ICollection<PlaylistVideoEntity> PlaylistVideos { get; set; }
    }
}