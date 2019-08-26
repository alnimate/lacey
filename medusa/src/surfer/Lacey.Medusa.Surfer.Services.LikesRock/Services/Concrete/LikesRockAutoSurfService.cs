using System.Threading.Tasks;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services.Concrete
{
    public sealed class LikesRockAutoSurfService : LikesRockService, ILikesRockAutoSurfService
    {
        #region Fields/Constructors

        private readonly ILogger logger;

        public LikesRockAutoSurfService(ILogger logger)
        {
            this.logger = logger;
        }

        #endregion

        public async Task AutoSurf()
        {
        }
    }
}