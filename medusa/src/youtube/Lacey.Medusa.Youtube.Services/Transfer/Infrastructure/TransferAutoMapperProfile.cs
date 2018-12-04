using AutoMapper;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Domain.Entities;

namespace Lacey.Medusa.Youtube.Services.Transfer.Infrastructure
{
    public class TransferAutoMapperProfile : Profile
    {
        public TransferAutoMapperProfile()
        {
            this.CreateMap<Channel, ChannelEntity>()
                .ConstructUsing(m => new ChannelEntity
                {
                    ChannelId = m.Id,
                    Name = m.Snippet.Title,
                    Description = m.Snippet.Description,
                    PublishedAt = m.Snippet.PublishedAt 
                });

            this.CreateMap<Video, VideoEntity>()
                .ConstructUsing(m => new VideoEntity
                {
                    VideoId = m.Id,
                    Name = m.Snippet.Title,
                    Description = m.Snippet.Description,
                    PublishedAt = m.Snippet.PublishedAt
                });

            this.CreateMap<Playlist, PlaylistEntity>()
                .ConstructUsing(m => new PlaylistEntity
                {
                    PlaylistId = m.Id,
                    Name = m.Snippet.Title,
                    Description = m.Snippet.Description,
                    PublishedAt = m.Snippet.PublishedAt
                });
        }
    }
}