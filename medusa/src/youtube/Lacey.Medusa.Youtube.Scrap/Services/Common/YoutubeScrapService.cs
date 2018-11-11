using AutoMapper;
using Lacey.Medusa.Youtube.Scrap.Base;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Scrap.Services.Common
{
    public abstract class YoutubeScrapService
    {
        internal IYoutubeClient Youtube { get; }

        protected readonly IMapper Mapper;

        protected readonly ILogger Logger;

        protected YoutubeScrapService(
            IMapper mapper, 
            ILogger<YoutubeScrapService> logger)
        {
            Mapper = mapper;
            this.Logger = logger;
            Youtube = new YoutubeClient();
        }
    }
}