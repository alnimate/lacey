using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Custom.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Const;
using Lacey.Medusa.Surfer.Services.LikesRock.Delegates;
using Lacey.Medusa.Surfer.Services.LikesRock.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.GetTasks;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.RecordAction;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Tasks;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Lacey.Medusa.Surfer.Services.LikesRock.Serializers;
using Lacey.Medusa.Surfer.Services.LikesRock.Utils;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services.Concrete
{
    public sealed class LrTasksService : LrService, ILrTasksService
    {
        public event TasksCompletedDelegate OnTasksCompleted;

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

            var tasksCompleted = new List<TaskCompleted>();
            await ProceedUtils.Proceed<bool?>(this.Logger, async () => {
                var tasks = new List<GetTasksItemModel>();
                foreach (var social in Socials.All)
                {
                    var usersSocial = this.UserSecrets.GetUsersSocial(social.Name);
                    if (usersSocial != null)
                    {
                        foreach (var target in social.Targets)
                        {
                            var ts = await GetTasks(target.Id, usersSocial.Id);
                            this.Logger.LogTrace($"{usersSocial.Name} - {target.Name} : {ts.Length} tasks.");
                            tasks.AddRange(ts);
                        }
                    }
                }
                this.Logger.LogTrace($"Tasks total {tasks.Count}.");
                if (!tasks.Any())
                {
                    this.DoTasksCompleted(tasksCompleted);
                    this.Logger.LogTrace("No tasks for now. Closing...");
                    DelayUtils.LargeDelay();
                    return true;
                }

                var sorted = tasks
                    .OrderByDescending(t => t.Money)
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
                        UserSession.UserId,
                        task.SocialId,
                        this.CommonSecrets.HashKey);

                    var recordActionRequest = this.Lr.Ajax.RecordAction(
                            UserSession.UserAccessToken,
                            task.TaskId.ToString(),
                            task.SocialId,
                            taskHash,
                            string.Empty)
                        .SetAuthCookies(AuthCookies)
                        .SetSerializer(new JsonSerializer<RecordActionResponseModel>());

                    var recordActionResponse = await recordActionRequest.ExecuteAsync();
                    tasksCompleted.Add(new TaskCompleted(task, recordActionResponse));
                    this.Logger.LogTrace(recordActionResponse.GetLog());
                }

                return null;
            });
        }

        private async Task<GetTasksItemModel[]> GetTasks(int targetId, string socialId)
        {
            var tasksRequest = this.Lr.GetTasks.GetTasks(UserSession.UserAccessToken, targetId, ClientVersion)
                .SetAuthCookies(AuthCookies)
                .SetSerializer(new GetTasksSerializer());
            var tasks = (await tasksRequest.ExecuteAsync()).Tasks
                .Where(t => t.Currency == Currency.Euro)
                .ToArray();
            if (!string.IsNullOrEmpty(socialId))
            {
                foreach (var task in tasks)
                {
                    task.SocialId = socialId;
                }
            }
            return tasks;
        }

        private void DoTasksCompleted(List<TaskCompleted> tasksCompleted)
        {
            OnTasksCompleted?.Invoke(tasksCompleted);
        }
    }
}