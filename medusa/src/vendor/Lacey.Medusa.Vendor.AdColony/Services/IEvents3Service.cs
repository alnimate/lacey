using System.Threading.Tasks;
using Lacey.Medusa.Vendor.AdColony.Models.Events3.Rewardv4vc;

namespace Lacey.Medusa.Vendor.AdColony.Services
{
    public interface IEvents3Service
    {
        Task<Rewardv4VcModel> Rewardv4Vc(string pl, Rewardv4VcRequestModel req);
    }
}