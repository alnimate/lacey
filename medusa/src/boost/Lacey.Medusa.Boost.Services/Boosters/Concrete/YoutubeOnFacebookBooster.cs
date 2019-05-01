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

        private readonly IReadOnlyList<string> firstNames;

        private readonly IReadOnlyList<string> lastNames;

        public YoutubeOnFacebookBooster(
            IFacebookBoostProvider facebookProvider,
            ILogger<YoutubeOnFacebookBooster> logger,
            INamesGenerator generator)
        {
            this.facebookProvider = facebookProvider;
            this.logger = logger;

            this.firstNames = generator.GenerateFirstNames();
            this.lastNames = generator.GenerateLastNames();
        }

        public async Task<bool> Boost(
            ChannelEntity channel,
            Youtube.Domain.Entities.ChannelEntity youtubeChannel,
            Video video)
        {
            var query = $"{this.firstNames.GetRandomName()} {this.lastNames.GetRandomName()}";
            var users = this.facebookProvider.SearchPeopleAsync(query);

            return false;
        }
    }
}