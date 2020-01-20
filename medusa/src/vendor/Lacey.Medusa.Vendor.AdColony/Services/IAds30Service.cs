using System.Threading.Tasks;
using Lacey.Medusa.Vendor.AdColony.Models.Ads30.Configure;

namespace Lacey.Medusa.Vendor.AdColony.Services
{
    public interface IAds30Service
    {
        Task<ConfigureModel> Configure();
    }
}