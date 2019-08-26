using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers.Concrete;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Common
{
    public abstract class LikesRockService
    {
        protected readonly LikesRockProvider LikesRock;

        protected LikesRockService()
        {
            this.LikesRock = new LikesRockProvider(new BaseClientService.Initializer());
        }
    }
}