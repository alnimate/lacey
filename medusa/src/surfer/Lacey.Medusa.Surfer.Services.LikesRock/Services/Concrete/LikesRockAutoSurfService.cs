using System.Threading.Tasks;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services.Concrete
{
    public sealed class LikesRockAutoSurfService : LikesRockService, ILikesRockAutoSurfService
    {
        #region Fields/Constructors

        public LikesRockAutoSurfService(
            ILogger logger,
            ILikesRockAuthProvider authProvider) : base(logger, authProvider)
        {
        }

        #endregion

        public async Task AutoSurf()
        {
            var getSurfUrlRequest = this.LikesRock.Ajax.GetSurfUrl(LoginInfo.UserAccessToken);

            var getSurfUrlResponse = await getSurfUrlRequest.ExecuteAsync();
        }
    }
}