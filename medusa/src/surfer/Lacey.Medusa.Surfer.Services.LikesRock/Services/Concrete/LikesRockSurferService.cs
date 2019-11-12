using System.Threading.Tasks;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services.Concrete
{
    public sealed class LikesRockSurferService : LikesRockService, ILikesRockSurferService
    {
        #region Fields/Constructors

        private readonly ILikesRockAutoSurfService likesRockAutoSurfService;

        private readonly ILrWebsitesService lrWebsitesService;

        public LikesRockSurferService(
            ILogger logger,
            ILikesRockAuthProvider authProvider,
            ILikesRockAutoSurfService likesRockAutoSurfService, 
            ILrWebsitesService lrWebsitesService) : base(logger, authProvider)
        {
            this.likesRockAutoSurfService = likesRockAutoSurfService;
            this.lrWebsitesService = lrWebsitesService;
        }

        #endregion

        public async Task Surf()
        {
            await this.lrWebsitesService.Surf();
            await this.likesRockAutoSurfService.Surf();
        }
    }
}