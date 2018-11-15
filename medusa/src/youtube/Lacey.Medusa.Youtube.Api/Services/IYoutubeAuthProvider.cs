using System.Threading.Tasks;
using Lacey.Medusa.Common.Auth.OAuth2.Base.OAuth2;

namespace Lacey.Medusa.Youtube.Api.Services
{
    public interface IYoutubeAuthProvider
    {
        Task<UserCredential> GetUserCredentials();
    }
}