using InstagramApiSharp.Classes;

namespace Lacey.Medusa.Instagram.Api.Services
{
    public interface IInstagramAuthProvider
    {
        UserSessionData GetUserSessionData();
    }
}