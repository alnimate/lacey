using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Custom.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.GetSurfUrl;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.RecordAction;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Lacey.Medusa.Surfer.Services.LikesRock.Serializers;
using Lacey.Medusa.Surfer.Services.LikesRock.Utils;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services.Concrete
{
    public sealed class LrAutoSurfService : LrService, ILrAutoSurfService
    {
        #region Fields/Constructors

        public LrAutoSurfService(
            ILogger logger,
            ILrAuthProvider authProvider) : base(logger, authProvider)
        {
        }

        #endregion

        public async Task Surf()
        {
            if (!this.IsAuthenticated())
            {
                return;
            }

            await ProceedUtils.Proceed<bool?>(this.Logger, async () => {
                var getSurfUrlRequest = this.Lr.Ajax.GetSurfUrl(UserSession.UserAccessToken)
                    .SetAuthCookies(AuthCookies)
                    .SetSerializer(new JsonSerializer<GetSurfUrlResponseModel>());

                var getSurfUrlResponse = await getSurfUrlRequest.ExecuteAsync();
                this.Logger.LogTrace(getSurfUrlResponse.GetLog());
                DelayUtils.TaskDelay(getSurfUrlResponse.TaskTime);
                if (getSurfUrlResponse.NoAutoSurf())
                {
                    return true;
                }

                var taskHash = CryptoUtils.GetTaskHash(
                    getSurfUrlResponse.TaskId,
                    UserSession.UserId,
                    string.Empty,
                    this.CommonSecrets.HashKey);

                var recordActionRequest = this.Lr.Ajax.RecordAction(
                        UserSession.UserAccessToken,
                        getSurfUrlResponse.TaskId,
                        string.Empty,
                        taskHash,
                        string.Empty)
                    .SetAuthCookies(AuthCookies)
                    .SetSerializer(new JsonSerializer<RecordActionResponseModel>());

                var recordActionResponse = await recordActionRequest.ExecuteAsync();
                this.Logger.LogTrace(recordActionResponse.GetLog());
                return null;
            });
        }
    }
}