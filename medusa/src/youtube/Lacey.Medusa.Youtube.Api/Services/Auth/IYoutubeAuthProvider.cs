using System.Threading.Tasks;
using Lacey.Medusa.Common.Auth.OAuth2.Base.OAuth2;

namespace Lacey.Medusa.Youtube.Api.Services.Auth
{
    public interface IYoutubeAuthProvider
    {
        string GetApiKey();

        Task<UserCredential> GetUserCredentials();
    }
}