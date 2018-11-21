using Lacey.Medusa.Youtube.Api.Services;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Services.Common.Services
{
    public abstract class YoutubeService
    {
        protected IYoutubeProvider YoutubeProvider;

        protected readonly ILogger Logger;

        protected YoutubeService(
            IYoutubeProvider youtubeProvider, 
            ILogger<YoutubeService> logger)
        {
            this.YoutubeProvider = youtubeProvider;
            this.Logger = logger;
        }
    }
}