using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services.Concrete
{
    public sealed class LrLoginService : LrService, ILrLoginService
    {
        public LrLoginService(ILogger logger, ILrAuthProvider authProvider) : base(logger, authProvider)
        {
        }
    }
}