using System;
using System.Collections.Generic;
using AutoMapper;
using Lacey.Medusa.Youtube.Domain.Entities;
using Lacey.Medusa.Youtube.Services.Store.Models;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Download;

namespace Lacey.Medusa.Youtube.Services.Store.Infrastructure
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            // Download => Store
            this.CreateMap<DownloadVideo, StoreVideo>()
                .ConstructUsing(d => new StoreVideo(
                    d.VideoId,
                    d.Title,
                    d.Description,
                    d.PublishedAt ?? DateTime.UtcNow));

            this.CreateMap<DownloadChannelInfo, StoreChannelInfo>()
                .ConstructUsing(d => new StoreChannelInfo(
                    d.ChannelId,
                    d.Title,
                    d.Description));

            this.CreateMap<DownloadChannel, StoreChannel>()
                .ConstructUsing(d => new StoreChannel(
                    Mapper.Map<StoreChannelInfo>(d.Channel),
                    Mapper.Map<IEnumerable<StoreVideo>>(d.Videos)));


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