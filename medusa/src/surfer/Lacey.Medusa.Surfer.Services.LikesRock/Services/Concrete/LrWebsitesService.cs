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
    public sealed class LrWebsitesService : LikesRockService, ILrWebsitesService
    {
        public LrWebsitesService(
            ILogger logger, 
            ILikesRockAuthProvider authProvider) : base(logger, authProvider)
        {
        }

        public async Task Surf()
        {
            var getTasksRequest = this.LikesRock.GetTasks.GetTasks(LoginInfo.UserAccessToken, Target.Websites, ClientVersion)
                    .AddConnection("keep-alive")
                    .AddAccept("text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8")
                    .AddAcceptLanguage("en-US,en;q=0.8")
                    .AddCookies(AuthCookies)
                    .SetSerializer(new GetTasksSerializer());

            var getTasksResponse = await getTasksRequest.ExecuteAsync();

            foreach (var task in getTasksResponse.Tasks
                .OrderBy(t => t.Currency)
                .ThenByDescending(t => t.Money)
                .ToArray())
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

                var recordActionRequest = this.LikesRock.Ajax.RecordAction(
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