using System.Threading.Tasks;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.GetStats;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.UpdateAllInfo;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services
{
    public interface ILrStatsService
    {
        Task<UpdateAllInfoResponseModel> UpdateAllInfo();

        Task<GetStatsResponseModel> GetStats();
    }
}