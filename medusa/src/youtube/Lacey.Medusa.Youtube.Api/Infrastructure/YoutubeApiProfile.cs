using AutoMapper;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Common.Models.About;
using Lacey.Medusa.Youtube.Common.Models.Common;
using Lacey.Medusa.Youtube.Common.Models.Videos;

namespace Lacey.Medusa.Youtube.Api.Infrastructure
{
    public class YoutubeApiProfile : Profile
    {
        public YoutubeApiProfile()
        {
            this.CreateMap<Thumbnail, YoutubeThumbnail>()
                .ConstructUsing(t => new YoutubeThumbnail(t.Url));

            this.CreateMap<ThumbnailDetails, YoutubeThumbnails>()
                .ConstructUsing(t => new YoutubeThumbnails(
                    Mapper.Map<YoutubeThumbnail>(t.Default__),
                    Mapper.Map<YoutubeThumbnail>(t.Medium),
                    Mapper.Map<YoutubeThumbnail>(t.High),
                    Mapper.Map<YoutubeThumbnail>(t.Standard),
                    Mapper.Map<YoutubeThumbnail>(t.Maxres)));

            this.CreateMap<SearchResult, YoutubeVideo>()
                .ConstructUsing(v => new YoutubeVideo(v.Id.VideoId,
                    v.Snippet.Title,
                    v.Snippet.Description,
                    v.Snippet.PublishedAt,
                    Mapper.Map<YoutubeThumbnails>(v.Snippet.Thumbnails),
                    null));

            this.CreateMap<ChannelSnippet, YoutubeAbout>()
                .ConstructUsing(s => new YoutubeAbout(s.Description));
        }
    }
}