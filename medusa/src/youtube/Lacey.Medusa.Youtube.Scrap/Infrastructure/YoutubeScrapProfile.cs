using AutoMapper;
using Lacey.Medusa.Youtube.Common.Models.Common;
using Lacey.Medusa.Youtube.Common.Models.Videos;
using Lacey.Medusa.Youtube.Scrap.Base.Models;

namespace Lacey.Medusa.Youtube.Scrap.Infrastructure
{
    public class YoutubeScrapProfile : Profile
    {
        public YoutubeScrapProfile()
        {
            this.CreateMap<ThumbnailSet, YoutubeThumbnails>()
                .ConstructUsing(s => new YoutubeThumbnails(
                    new YoutubeThumbnail(s.LowResUrl),
                    new YoutubeThumbnail(s.MediumResUrl),
                    new YoutubeThumbnail(s.HighResUrl),
                    new YoutubeThumbnail(s.StandardResUrl),
                    new YoutubeThumbnail(s.MaxResUrl)));

            this.CreateMap<Video, YoutubeVideo>()
                .ConstructUsing(v => new YoutubeVideo(
                    v.Id,
                    v.Title,
                    v.Description,
                    v.UploadDate.UtcDateTime,
                    Mapper.Map<YoutubeThumbnails>(v.Thumbnails),
                    v.Keywords));
        }
    }
}