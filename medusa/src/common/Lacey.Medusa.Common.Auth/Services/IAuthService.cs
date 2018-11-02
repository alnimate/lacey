using System.Threading.Tasks;
using Lacey.Medusa.Common.Auth.Models;

namespace Lacey.Medusa.Common.Auth.Services
{
    public interface IAuthService
    {
        Task<RegisterResult> Register(Register register);

        Task<LoginResult> Login(Login login);
    }
}