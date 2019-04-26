using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Medusa.Boost.Services.Extensions;
using Lacey.Medusa.Boost.Services.Providers;
using Lacey.Medusa.Common.Generators.Generators;
using Lacey.Medusa.Instagram.Domain.Entities;
using Lacey.Medusa.Youtube.Api.Base;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Boost.Services.Boosters.Concrete
{
    public sealed class YoutubeOnFacebookBooster
    {
        private readonly IFacebookBoostProvider facebookProvider;

        private readonly ILogger logger;

        private readonly IReadOnlyList<string> names;

        public YoutubeOnFacebookBooster(
            IFacebookBoostProvider facebookProvider,
            ILogger<YoutubeOnFacebookBooster> logger,
            INamesGenerator generator)
        {
            this.facebookProvider = facebookProvider;
            this.logger = logger;

            this.names = generator.GenerateFirstNames();
        }

        public async Task<bool> Boost(
            ChannelEntity channel,
            Youtube.Domain.Entities.ChannelEntity youtubeChannel,
            Video video)
        {
            var query = this.names.GetRandomName();
            var users = this.facebookProvider.SearchPeopleAsync(query);

            return false;
        }
    }
}