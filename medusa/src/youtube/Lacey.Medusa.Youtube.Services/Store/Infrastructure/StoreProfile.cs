using System;
using AutoMapper;
using Lacey.Medusa.Youtube.Domain.Entities;
using Lacey.Medusa.Youtube.Services.Store.Models;

namespace Lacey.Medusa.Youtube.Services.Store.Infrastructure
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            // Download => Store

            // Store => Entity
            this.CreateMap<StoreVideo, VideoEntity>()
                .ConstructUsing(s => new VideoEntity
                {
                    ChannelId = s.ChannelId,
                    VideoId = s.VideoId,
                    Name = s.Title,
                    Description = s.Description,
                    PublishedAt = s.PublishedAt,
                    CreatedAt = DateTime.UtcNow
                });

            this.CreateMap<StoreChannelInfo, ChannelEntity>()
                .ConstructUsing(s => new ChannelEntity
                {
                    ChannelId = s.ChannelId,
                    Name = s.Title,
                    Description = s.Description
                });
        }
    }
}