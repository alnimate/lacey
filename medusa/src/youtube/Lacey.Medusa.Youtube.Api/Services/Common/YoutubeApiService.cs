using AutoMapper;
using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Api.Services.Auth;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Lacey.Medusa.Youtube.Api.Services.Common
{
    public abstract class YoutubeApiService
    {
        internal YouTubeService Youtube { get; }

        internal YouTubeService YoutubeOAuth2 { get; }

        protected readonly IMapper Mapper;

        protected readonly ILogger Logger;

        protected YoutubeApiService(
            IYoutubeAuthProvider youtubeAuthProvider, 
            IMapper mapper, 
            ILogger<YoutubeApiService> logger)
        {
            this.Mapper = mapper;
            Logger = logger;

            var applicationName = GetType().ToString();

            this.Youtube = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = youtubeAuthProvider.GetApiKey(),
                ApplicationName = applicationName
            });

            this.YoutubeOAuth2 = new YouTubeService(new BaseClientService.Initializer
            {
                HttpClientInitializer = youtubeAuthProvider.GetUserCredentials().Result,
                ApplicationName = applicationName
            });
        }
    }
}