using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lacey.Medusa.Common.Services.Models.Business;

namespace Lacey.Medusa.Youtube.Services.Management.Models.Channels.Entity
{
    public sealed class Channel: IntIdBusinessModel
    {
        public Channel(
            int id,
            string channelId, 
            string name,
            string description,
            DateTime createdAt, 
            IEnumerable<ChannelVideo> videos)
            : base(id)
        {
            ChannelId = channelId;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
            Videos = videos;
        }

        [Required]
        [MaxLength(30)]
        public string ChannelId { get; }

        [Required]
        [MaxLength(30)]
        public string Name { get; }

        public string Description { get; }

        public DateTime CreatedAt { get; }

        public IEnumerable<ChannelVideo> Videos { get; }
    }
}