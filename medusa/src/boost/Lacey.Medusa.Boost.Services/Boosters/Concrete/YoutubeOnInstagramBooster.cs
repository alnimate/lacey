using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Boost.Services.Extensions;
using Lacey.Medusa.Boost.Services.Providers;
using Lacey.Medusa.Instagram.Domain.Entities;
using Lacey.Medusa.Youtube.Api.Base;
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
            ChannelEntity channel,
            Youtube.Domain.Entities.ChannelEntity youtubeChannel,
            Video video)
        {
            var query = video.GetInstagramQuery(new[]
            {
                channel.OriginalChannelId,
                youtubeChannel.Name
            });
            if (string.IsNullOrEmpty(query))
            {
                return false;
            }

            var result = await this.instagramProvider.SearchPeopleAsync(query);
            if (!result.Succeeded)
            {
                this.logger.LogError($"{result.Info?.Message}");
                return false;
            }

            var users = result.Value.Users
                .OrderBy(u => u.FollowersCount)
                .Take(20)
                .Shuffle()
                .ToList();

            if (!users.Any()) 
            {
                return false;
            }

            foreach (var user in users)
            {
                if (user.UserName == channel.OriginalChannelId ||
                    user.UserName == channel.ChannelId)
                {
                    continue;
                }

                var mediaList = await this.instagramProvider.GetLastMedia(user.UserName);
                if (mediaList == null || !mediaList.Any())
                {
                    continue;
                }

                var media = mediaList
                    .Take(3)
                    .Shuffle()
                    .FirstOrDefault();
                if (media?.Caption == null ||
                    string.IsNullOrEmpty(media.Caption.MediaId))
                {
                    continue;
                }

                var res = await this.instagramProvider.CommentMediaAsync(
                    media.Caption.MediaId,
                    video.GetInstagramBoostText());
                if (!res.Succeeded)
                {
                    this.logger.LogError($"{res.Info?.Message}");
                    continue;
                }
                
                this.logger.LogTrace($"{media.GetInstagramUrl()}");
                return true;
            }

            return false;
        }
    }
}