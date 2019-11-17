using System.Threading.Tasks;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services.Concrete
{
    public sealed class LrSurfService : LrService, ILrSurfService
    {
        #region Fields/Constructors

        private readonly ILrAutoSurfService lrAutoSurfService;

        private readonly ILrTasksService lrTasksService;

        private readonly ILrStatsService lrStatsService;

        private readonly ILrLoginService lrLoginService;

        public LrSurfService(
            ILogger logger,
            ILrAuthProvider authProvider,
            ILrAutoSurfService lrAutoSurfService, 
            ILrTasksService lrTasksService, 
            ILrStatsService lrStatsService, 
            ILrLoginService lrLoginService) : base(logger, authProvider)
        {
            this.lrAutoSurfService = lrAutoSurfService;
            this.lrTasksService = lrTasksService;
            this.lrStatsService = lrStatsService;
            this.lrLoginService = lrLoginService;
        }

        #endregion

        public async Task Surf()
        {
            this.lrLoginService.Login();

            var stats = await this.lrStatsService.GetStats();
            this.Logger.LogTrace(stats.GetLog());

            await this.lrTasksService.Surf();

            await this.lrAutoSurfService.Surf();
        }
    }
}