using System.Threading.Tasks;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services.Concrete
{
    public sealed class LikesRockAuthService : LikesRockService, ILikesRockAuthService
    {
        #region Fields/Constructors

        private readonly ILikesRockAuthProvider authProvider;

        private readonly ILogger logger;

        public LikesRockAuthService(
            ILikesRockAuthProvider authProvider, 
            ILogger logger)
        {
            this.authProvider = authProvider;
            this.logger = logger;
        }

        #endregion

        public async Task Login()
        {
            var credentials = this.authProvider.GetCredentials();
        }
    }
}