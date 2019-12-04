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

        private readonly ILrTasksService lrTasksService;

        private readonly ILrStatsService lrStatsService;

        private readonly ILrLoginService lrLoginService;

        public LrSurfService(
            ILogger logger,
            ILrAuthProvider authProvider,
            ILrTasksService lrTasksService, 
            ILrStatsService lrStatsService, 
            ILrLoginService lrLoginService) : base(logger, authProvider)
        {
            this.lrTasksService = lrTasksService;
            this.lrStatsService = lrStatsService;
            this.lrLoginService = lrLoginService;
        }

        #endregion

        public async Task Surf()
        {
            await this.lrLoginService.Login();

            var updateAllInfo = await this.lrStatsService.UpdateAllInfo();
            this.Logger.LogTrace(updateAllInfo.GetLog());

            await this.lrTasksService.Surf();
        }
    }
}