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
            while (true)
            {
                var getSurfUrlRequest = this.LikesRock.Ajax.GetSurfUrl(LoginInfo.UserAccessToken)
                    .SetSerializer(new JsonSerializer<GetSurfUrlResponseModel>());

                var getSurfUrlResponse = await getSurfUrlRequest.ExecuteAsync();
                this.Logger.LogTrace(getSurfUrlResponse.GetLog());
                TaskUtils.Delay(getSurfUrlResponse.TaskTime);

                var taskHash = CryptoUtils.GetTaskHash(
                    getSurfUrlResponse.TaskId,
                    LoginInfo.UserId,
                    string.Empty,
                    this.CommonSecrets.HashKey);

                var recordActionRequest = this.LikesRock.Ajax.RecordAction(
                        LoginInfo.UserAccessToken,
                        getSurfUrlResponse.TaskId,
                        string.Empty,
                        taskHash,
                        string.Empty)
                    .SetSerializer(new JsonSerializer<RecordActionResponseModel>());

                var recordActionResponse = await recordActionRequest.ExecuteAsync();
                this.Logger.LogTrace(recordActionResponse.GetLog());
            }
        }
    }
}