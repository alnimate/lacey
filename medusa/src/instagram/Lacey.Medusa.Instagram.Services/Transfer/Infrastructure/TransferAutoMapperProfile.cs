using AutoMapper;
using InstagramApiSharp.Classes.Models;
using Lacey.Medusa.Instagram.Domain.Entities;
using Lacey.Medusa.Instagram.Services.Extensions;
using Newtonsoft.Json;

namespace Lacey.Medusa.Instagram.Services.Transfer.Infrastructure
{
    public class TransferAutoMapperProfile : Profile
    {
        public TransferAutoMapperProfile()
        {
            this.CreateMap<InstaUserInfo, ChannelEntity>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ConstructUsing(u => new ChannelEntity
                {
                    ChannelId = u.Username,
                    Name = u.FullName,
                    Description = JsonConvert.SerializeObject(u)
                });

            this.CreateMap<InstaMedia, MediaEntity>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ConstructUsing(m => new MediaEntity
                {
                    OriginalMediaId = m.Caption != null ? m.Caption.MediaId : string.Empty,
                    Name = m.Caption != null ? m.Caption.Text : null,
                    Description = JsonConvert.SerializeObject(m),
                    PublishedAt = m.GetMediaDate()
                });
        }
    }
}