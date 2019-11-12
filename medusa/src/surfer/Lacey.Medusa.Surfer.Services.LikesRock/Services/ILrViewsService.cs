using System.Threading.Tasks;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services
{
    public interface ILrViewsService
    {
        Task WebsitesSurf();

        Task YoutubeSurf();
    }
}