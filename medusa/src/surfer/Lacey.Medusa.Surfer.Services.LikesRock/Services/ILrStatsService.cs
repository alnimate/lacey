using System.Threading.Tasks;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.GetStats;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services
{
    public interface ILrStatsService
    {
        Task<GetStatsResponseModel> GetStats();
    }
}