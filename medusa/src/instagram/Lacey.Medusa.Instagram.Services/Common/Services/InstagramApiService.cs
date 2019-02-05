using Lacey.Medusa.Instagram.Api.Services;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Instagram.Services.Common.Services
{
    public abstract class InstagramApiService
    {
        protected IInstagramProvider InstagramProvider;

        protected readonly ILogger Logger;

        protected InstagramApiService(
            IInstagramProvider instagramProvider, 
            ILogger<InstagramApiService> logger)
        {
            this.InstagramProvider = instagramProvider;
            this.Logger = logger;
        }
    }
}