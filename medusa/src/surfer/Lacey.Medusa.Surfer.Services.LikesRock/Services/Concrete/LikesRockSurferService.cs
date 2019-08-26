using System.Threading.Tasks;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services.Concrete
{
    public sealed class LikesRockSurferService : LikesRockService, ILikesRockSurferService
    {
        #region Fields/Constructors

        private readonly ILogger logger;

        private readonly ILikesRockAuthService likesRockAuthService;

        private readonly ILikesRockAutoSurfService likesRockAutoSurfService;

        public LikesRockSurferService(ILogger logger, 
            ILikesRockAuthService likesRockAuthService, 
            ILikesRockAutoSurfService likesRockAutoSurfService)
        {
            this.logger = logger;
            this.likesRockAuthService = likesRockAuthService;
            this.likesRockAutoSurfService = likesRockAutoSurfService;
        }

        #endregion


        public async Task Surf()
        {
            await this.likesRockAuthService.Login();

            await this.likesRockAutoSurfService.AutoSurf();
        }
    }
}