using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Custom.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.GetSurfUrl;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.RecordAction;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Lacey.Medusa.Surfer.Services.LikesRock.Serializers;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services.Concrete
{
    public sealed class LikesRockAutoSurfService : LikesRockService, ILikesRockAutoSurfService
    {
        #region Fields/Constructors

        public LikesRockAutoSurfService(
            ILogger logger,
            ILikesRockAuthProvider authProvider) : base(logger, authProvider)
        {
        }

        #endregion

        public async Task AutoSurf()
        {
            var getSurfUrlRequest = this.LikesRock.Ajax.GetSurfUrl(LoginInfo.UserAccessToken)
                .SetSerializer(new JsonSerializer<GetSurfUrlResponseModel>());

            var getSurfUrlResponse = await getSurfUrlRequest.ExecuteAsync();

            var recordActionRequest = this.LikesRock.Ajax.RecordAction(
                LoginInfo.UserAccessToken,
                "1480643",
                string.Empty,
                "AAF0CD1C50D10BBCBC517779A6448DFA",
                string.Empty)
                .SetSerializer(new JsonSerializer<RecordActionResponseModel>());

            var recordActionResponse = await recordActionRequest.ExecuteAsync();
        }
    }
}