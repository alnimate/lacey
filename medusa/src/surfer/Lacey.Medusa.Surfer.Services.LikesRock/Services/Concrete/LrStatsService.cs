using System;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Custom.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.GetStats;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Lacey.Medusa.Surfer.Services.LikesRock.Serializers;
using Lacey.Medusa.Surfer.Services.LikesRock.Utils;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services.Concrete
{
    public sealed class LrStatsService : LrService, ILrStatsService
    {
        public LrStatsService(ILogger logger, ILrAuthProvider authProvider) : base(logger, authProvider)
        {
        }

        public async Task<GetStatsResponseModel> GetStats()
        {
            if (!this.IsAuthenticated())
            {
                return null;
            }

            var getStatsRequest = this.Lr.GetStats.GetStats(
                LoginInfo.UserAccessToken,
                UserLang,
                ClientVersion)
                .SetAuthCookies(AuthCookies)
                .SetSerializer(new GetStatsSerializer());

            GetStatsResponseModel stats = null;
            try
            {
                stats = await getStatsRequest.ExecuteAsync();
                DelayUtils.SmallDelay();
            }
            catch (Exception e)
            {
                this.Logger.LogError(e.ToString());
            }

            return stats;
        }
    }
}