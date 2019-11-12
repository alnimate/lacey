using System.Threading.Tasks;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services.Concrete
{
    public sealed class LrSurfService : LrService, ILrSurfService
    {
        #region Fields/Constructors

        private readonly ILrAutoSurfService lrAutoSurfService;

        private readonly ILrViewsService lrViewsService;

        private readonly ILrLoginService lrLoginService;

        public LrSurfService(
            ILogger logger,
            ILrAuthProvider authProvider,
            ILrAutoSurfService lrAutoSurfService, 
            ILrViewsService lrViewsService, 
            ILrLoginService lrLoginService) : base(logger, authProvider)
        {
            this.lrAutoSurfService = lrAutoSurfService;
            this.lrViewsService = lrViewsService;
            this.lrLoginService = lrLoginService;
        }

        #endregion

        public async Task Surf()
        {
            this.lrLoginService.Login();
            if (!this.lrLoginService.IsAuthenticated())
            {
                this.Logger.LogError("Authorization failed.");
                return;
            }

            await this.lrViewsService.YoutubeSurf();

            await this.lrViewsService.WebsitesSurf();

            await this.lrAutoSurfService.Surf();
        }
    }
}