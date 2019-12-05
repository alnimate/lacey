using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Email.Services.Email;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Tasks;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services.Concrete
{
    public sealed class LrSurfService : LrService, ILrSurfService
    {
        #region Fields/Constructors

        private readonly ILrTasksService lrTasksService;

        private readonly ILrStatsService lrStatsService;

        private readonly ILrLoginService lrLoginService;

        private readonly IEmailProvider emailProvider;

        private readonly bool isSendEmails;

        public LrSurfService(
            ILogger logger,
            ILrAuthProvider authProvider,
            ILrTasksService lrTasksService, 
            ILrStatsService lrStatsService, 
            ILrLoginService lrLoginService, 
            IEmailProvider emailProvider,
            bool isSendEmails) : base(logger, authProvider)
        {
            this.lrTasksService = lrTasksService;
            this.lrStatsService = lrStatsService;
            this.lrLoginService = lrLoginService;
            this.emailProvider = emailProvider;
            this.isSendEmails = isSendEmails;

            this.lrTasksService.OnTasksCompleted += OnTasksCompleted;
        }

        #endregion

        public async Task Surf()
        {
            await this.lrLoginService.Login();

            var updateAllInfo = await this.lrStatsService.UpdateAllInfo();
            this.Logger.LogTrace(updateAllInfo.GetLog());

            await this.lrTasksService.Surf();
        }

        public void OnTasksCompleted(List<TaskCompleted> tasksCompleted)
        {
            try
            {
                var moneyEarned = tasksCompleted
                    .Where(t => t.RecordAction != null)
                    .Sum(t => t.RecordAction.TaskEarned.ParseMoney());
                var updateAllInfo = this.lrStatsService.UpdateAllInfo().Result;
                var report = new StringBuilder();
                report.AppendLine(updateAllInfo.GetLog());
                report.AppendLine($"Tasks completed {tasksCompleted.Count}.");
                report.AppendLine($"Money earned {moneyEarned} EUR.");
                this.Logger.LogTrace(report.ToString());

                if (this.isSendEmails)
                {
                    this.emailProvider.Send(
                        UserSession.UserEmail,
                        UserSession.UserEmail,
                        $"LikesRock {UserSession.UserName}",
                        report.ToString(),
                        false,
                        null);
                }
            }
            catch (Exception e)
            {
                this.Logger.LogError(e.Message);
            }
        }
    }
}