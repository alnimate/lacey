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

        public LikesRockSurferService(
            ILogger logger,
            ILikesRockAuthProvider authProvider,
            ILikesRockAutoSurfService likesRockAutoSurfService) : base(logger, authProvider)
        {
            this.likesRockAutoSurfService = likesRockAutoSurfService;
        }

        #endregion

        public async Task Surf()
        {
            if (!this.IsAuthenticated())
            {
                await this.Login();
            }

            await this.likesRockAutoSurfService.AutoSurf();
        }
    }
}