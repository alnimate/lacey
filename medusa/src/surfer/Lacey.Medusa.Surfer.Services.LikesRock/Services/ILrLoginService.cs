using System.Threading.Tasks;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services
{
    public interface ILrLoginService
    {
        bool IsAuthenticated();

        Task Login();
    }
}