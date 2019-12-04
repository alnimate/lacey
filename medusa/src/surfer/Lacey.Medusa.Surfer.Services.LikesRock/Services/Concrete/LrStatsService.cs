using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Custom.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.GetStats;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.UpdateAllInfo;
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

        public async Task<UpdateAllInfoResponseModel> UpdateAllInfo()
        {
            if (!this.IsAuthenticated())
            {
                return null;
            }

            return await ProceedUtils.Proceed(this.Logger, async () => {
                var updateAllInfoRequest = this.Lr.Ajax.UpdateAllInfo(UserSession.UserAccessToken)
                    .SetAuthCookies(AuthCookies);

                return await updateAllInfoRequest.ExecuteAsync();
            });
        }

        public async Task<GetStatsResponseModel> GetStats()
        {
            if (!this.IsAuthenticated())
            {
                return null;
            }

            return await ProceedUtils.Proceed(this.Logger, async () => {
                var getStatsRequest = this.Lr.GetStats.GetStats(
                        UserSession.UserAccessToken,
                        UserLang,
                        ClientVersion)
                    .SetAuthCookies(AuthCookies)
                    .SetSerializer(new GetStatsSerializer());

                return await getStatsRequest.ExecuteAsync();
            });
        }
    }
}