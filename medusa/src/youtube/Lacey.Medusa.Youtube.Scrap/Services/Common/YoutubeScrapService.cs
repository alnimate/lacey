using AutoMapper;
using Lacey.Medusa.Youtube.Scrap.Base;

namespace Lacey.Medusa.Youtube.Scrap.Services.Common
{
    public abstract class YoutubeScrapService
    {
        internal IYoutubeClient Youtube { get; }

        protected readonly IMapper Mapper;

        protected YoutubeScrapService(IMapper mapper)
        {
            Mapper = mapper;
            Youtube = new YoutubeClient();
        }
    }
}