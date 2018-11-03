using System.Collections.Generic;
using AutoMapper;
using Lacey.Medusa.Youtube.Domain.Entities;
using Lacey.Medusa.Youtube.Services.Youtube.Models.Channels.Entity;
using Lacey.Medusa.Youtube.Services.Youtube.Models.Videos.Entity;

namespace Lacey.Medusa.Youtube.Services.Youtube.Infrastructure
{
    public class YoutubeProfile : Profile
    {
        public YoutubeProfile()
        {
            // Entities
            this.CreateMap<VideoEntity, Video>()
                .ConstructUsing(
                    e => new Video(
                        e.Id,
                        e.VideoId,
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
                            Videos = Mapper.Map<ICollection<VideoEntity>>(m.Videos)
                        });
        }
    }
}