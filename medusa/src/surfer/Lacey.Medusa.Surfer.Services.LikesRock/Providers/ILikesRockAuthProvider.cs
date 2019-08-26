using Lacey.Medusa.Surfer.Services.LikesRock.Models.Auth;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Providers
{
    public interface ILikesRockAuthProvider
    {
        LikesRockCredentials GetCredentials();
    }
}