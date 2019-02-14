using Lacey.Medusa.Instagram.Api.Services;
using Lacey.Medusa.Instagram.Api.Services.Concrete;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Boost.Services.Services.Concrete
{
    public sealed class InstagramBoostProvider : InstagramProvider, IInstagramBoostProvider
    {
        #region Properties/Constructors

        private readonly ILogger logger;

        public InstagramBoostProvider(
            IInstagramAuthProvider instagramAuthProvider,
            ILogger<InstagramBoostProvider> logger)
            : base(instagramAuthProvider, logger)
        {
            this.logger = logger;
        }

        #endregion
    }
}