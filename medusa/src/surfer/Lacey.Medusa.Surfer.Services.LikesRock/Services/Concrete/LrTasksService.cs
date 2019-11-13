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

            // Youtube Subscribe
            var ytsr = this.Lr.GetTasks.GetTasks(LoginInfo.UserAccessToken, Target.YtSubscr, ClientVersion)
                    .SetAuthCookies(AuthCookies)
                    .SetSerializer(new GetTasksSerializer());
            var yts = await ytsr.ExecuteAsync();
            foreach (var task in yts.Tasks)
            {
                task.SocialId = this.UserSecrets.YoutubeSessionId;
            }
            tasks.AddRange(yts.Tasks);

            // Youtube Likes
            var ytlr = this.Lr.GetTasks.GetTasks(LoginInfo.UserAccessToken, Target.YtLikes, ClientVersion)
                    .SetAuthCookies(AuthCookies)
                    .SetSerializer(new GetTasksSerializer());
            var ytl = await ytlr.ExecuteAsync();
            foreach (var task in ytl.Tasks)
            {
                task.SocialId = this.UserSecrets.YoutubeSessionId;
            }
            tasks.AddRange(ytl.Tasks);

            // Youtube Views
            var ytr = this.Lr.GetTasks.GetTasks(LoginInfo.UserAccessToken, Target.YtViews, ClientVersion)
                    .SetAuthCookies(AuthCookies)
                    .SetSerializer(new GetTasksSerializer());
            var yt = await ytr.ExecuteAsync();
            tasks.AddRange(yt.Tasks);

            // Youtube Dislikes
            var ytdr = this.Lr.GetTasks.GetTasks(LoginInfo.UserAccessToken, Target.YtDislikes, ClientVersion)
                .SetAuthCookies(AuthCookies)
                .SetSerializer(new GetTasksSerializer());
            var ytd = await ytdr.ExecuteAsync();
            foreach (var task in ytd.Tasks)
            {
                task.SocialId = this.UserSecrets.YoutubeSessionId;
            }
            tasks.AddRange(ytd.Tasks);

            // Sites View
            var wr = this.Lr.GetTasks.GetTasks(LoginInfo.UserAccessToken, Target.SitesView, ClientVersion)
                    .SetAuthCookies(AuthCookies)
                    .SetSerializer(new GetTasksSerializer());
            var w = await wr.ExecuteAsync();
            tasks.AddRange(w.Tasks);

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
                TaskUtils.Delay(task.TaskTime);

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
                    .SetSerializer(new JsonSerializer<RecordActionResponseModel>());

                var recordActionResponse = await recordActionRequest.ExecuteAsync();
                this.Logger.LogTrace(recordActionResponse.GetLog());
            }
        }
    }
}