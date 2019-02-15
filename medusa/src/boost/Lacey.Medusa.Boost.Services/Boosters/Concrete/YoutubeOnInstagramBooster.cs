using System.Threading.Tasks;
using Lacey.Medusa.Boost.Services.Extensions;
using Lacey.Medusa.Boost.Services.Providers;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Boost.Services.Boosters.Concrete
{
    public sealed class YoutubeOnInstagramBooster
    {
        private readonly IInstagramBoostProvider instagramProvider;

        private readonly ILogger logger;

        public YoutubeOnInstagramBooster(
            IInstagramBoostProvider instagramProvider, 
            ILogger<YoutubeOnInstagramBooster> logger)
        {
            this.instagramProvider = instagramProvider;
            this.logger = logger;

            this.instagramProvider.Login().Wait();
        }

        public async Task<bool> Boost(
            string instagramChannelId,
            ChannelEntity localChannel,
            Video localVideo)
        {
            var query = localVideo.GetInstagramQuery(new[] { localChannel.Name });
            if (string.IsNullOrEmpty(query))
            {
                return false;
            }

            var result = await this.instagramProvider.SearchHashtagAsync(query);

            if (!result.Succeeded)
            {
                this.logger.LogError($"{result.Info?.Message}");
                return false;
            }

            return true;
        }
    }
}