using Lacey.Medusa.Youtube.Api.Services;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Services.Common.Services
{
    public abstract class YoutubeApiService
    {
        protected IYoutubeProvider YoutubeProvider;

        protected readonly ILogger Logger;

        protected YoutubeApiService(
            IYoutubeProvider youtubeProvider, 
            ILogger<YoutubeApiService> logger)
        {
            this.YoutubeProvider = youtubeProvider;
            this.Logger = logger;
        }
    }
}