using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Custom.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Const;
using Lacey.Medusa.Surfer.Services.LikesRock.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.GetTasks;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.RecordAction;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Lacey.Medusa.Surfer.Services.LikesRock.Serializers;
using Lacey.Medusa.Surfer.Services.LikesRock.Utils;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services.Concrete
{
    public sealed class LrTasksService : LrService, ILrTasksService
    {
        public LrTasksService(
            ILogger logger, 
            ILrAuthProvider authProvider) : base(logger, authProvider)
        {
        }

        public async Task Surf()
        {
            if (!this.IsAuthenticated())
            {
                return;
            }

            var tasks = new List<GetTasksItemModel>();
            foreach (var target in Targets.All)
            {
                var socialId = this.UserSecrets.GetSocialId(target.Social);
                if (!string.IsNullOrEmpty(socialId))
                {
                    foreach (var targetId in target.Ids)
                    {
                        tasks.AddRange(await GetTasks(targetId, socialId));
                    }
                }
            }

            var sorted = tasks
                .OrderBy(t => t.Currency)   
                .ThenByDescending(t => t.Money)
                .ThenBy(t => t.TaskTime)
                .ToArray();
            foreach (var task in sorted)
            {
                if (task.NoSurf())
                {
                    continue;
                }

                this.Logger.LogTrace(task.GetLog()
                    .Replace(Currency.Euro, Currency.EuroStr));
                DelayUtils.TaskDelay(task.TaskTime);

                var taskHash = CryptoUtils.GetTaskHash(
                    task.TaskId.ToString(),
                    LoginInfo.UserId,
                    task.SocialId,
                    this.CommonSecrets.HashKey);

                var recordActionRequest = this.Lr.Ajax.RecordAction(
                        LoginInfo.UserAccessToken,
                        task.TaskId.ToString(),
                        task.SocialId,
                        taskHash,
                        string.Empty)
                    .SetAuthCookies(AuthCookies)
                    .SetSerializer(new JsonSerializer<RecordActionResponseModel>());

                var recordActionResponse = await recordActionRequest.ExecuteAsync();
                this.Logger.LogTrace(recordActionResponse.GetLog());
            }
        }

        private async Task<IEnumerable<GetTasksItemModel>> GetTasks(int targetId, string socialId)
        {
            var tasksRequest = this.Lr.GetTasks.GetTasks(LoginInfo.UserAccessToken, targetId, ClientVersion)
                .SetAuthCookies(AuthCookies)
                .SetSerializer(new GetTasksSerializer());
            var tasks = (await tasksRequest.ExecuteAsync()).Tasks;
            if (!string.IsNullOrEmpty(socialId))
            {
                foreach (var task in tasks)
                {
                    task.SocialId = socialId;
                }
            }
            DelayUtils.SmallDelay();

            return tasks;
        }
    }
}