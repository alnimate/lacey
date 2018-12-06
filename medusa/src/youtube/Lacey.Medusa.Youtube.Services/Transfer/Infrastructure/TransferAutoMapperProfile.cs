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
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ConstructUsing(m => new ChannelEntity
                {
                    ChannelId = m.Id,
                    Name = m.Snippet.Title,
                    Description = m.Snippet.Description,
                    PublishedAt = m.Snippet.PublishedAt 
                });

            this.CreateMap<Video, VideoEntity>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ConstructUsing(m => new VideoEntity
                {
                    VideoId = m.Id,
                    Name = m.Snippet.Title,
                    Description = m.Snippet.Description,
                    PublishedAt = m.Snippet.PublishedAt
                });

            this.CreateMap<Playlist, PlaylistEntity>()
                .ForMember(e => e.Id, opt => opt.Ignore())
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