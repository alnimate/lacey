using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Custom.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Const;
using Lacey.Medusa.Surfer.Services.LikesRock.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.RecordAction;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Lacey.Medusa.Surfer.Services.LikesRock.Serializers;
using Lacey.Medusa.Surfer.Services.LikesRock.Utils;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services.Concrete
{
    public sealed class LrViewsService : LrService, ILrViewsService
    {
        public LrViewsService(
            ILogger logger, 
            ILrAuthProvider authProvider) : base(logger, authProvider)
        {
        }

        public async Task WebsitesSurf()
        {
            await this.Surf(Target.Websites);
        }

        public async Task YoutubeSurf()
        {
            await this.Surf(Target.Youtube);
        }

        private async Task Surf(int targetId)
        {
            if (!this.IsAuthenticated())
            {
                return;
            }

            var getTasksRequest = this.Lr.GetTasks.GetTasks(LoginInfo.UserAccessToken, targetId, ClientVersion)
                    .SetAuthCookies(AuthCookies)
                    .SetSerializer(new GetTasksSerializer());

            var getTasksResponse = await getTasksRequest.ExecuteAsync();
            var tasks = getTasksResponse.Tasks
                .OrderBy(t => t.Currency)
                .ThenByDescending(t => t.Money)
                .ThenBy(t => t.TaskTime)
                .ToArray();
            foreach (var task in tasks)
            {
                if (task.NoSurf())
                {
                    continue;
                }

                this.Logger.LogTrace(task.GetLog()
                    .Replace(Currency.Euro, Currency.EuroStr));
                TaskUtils.Delay(task.TaskTime);

                var taskHash = CryptoUtils.GetTaskHash(
                    task.TaskId.ToString(),
                    LoginInfo.UserId,
                    string.Empty,
                    this.CommonSecrets.HashKey);

                var recordActionRequest = this.Lr.Ajax.RecordAction(
                        LoginInfo.UserAccessToken,
                        task.TaskId.ToString(),
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