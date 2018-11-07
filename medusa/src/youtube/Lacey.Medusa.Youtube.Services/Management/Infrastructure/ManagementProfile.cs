using System.Collections.Generic;
using AutoMapper;
using Lacey.Medusa.Youtube.Domain.Entities;
using Lacey.Medusa.Youtube.Services.Management.Models.Channels.Entity;
using Lacey.Medusa.Youtube.Services.Management.Models.Videos.Entity;

namespace Lacey.Medusa.Youtube.Services.Management.Infrastructure
{
    public class ManagementProfile : Profile
    {
        public ManagementProfile()
        {
            // Entities
            this.CreateMap<VideoEntity, Video>()
                .ConstructUsing(
                    e => new Video(
                        e.Id,
                        e.VideoId,
                        e.Name,
                        e.Description,
                        e.PublishedAt,
                        e.ChannelId))
                .ReverseMap();

            this.CreateMap<Channel, ChannelEntity>()
                .ConstructUsing(
                    m => new ChannelEntity
                        {
                            Id = m.Id,
                            ChannelId = m.ChannelId,
                            Name = m.Name,
                            Description = m.Description,
                            Videos = Mapper.Map<ICollection<VideoEntity>>(m.Videos)
                        });
        }
    }
}