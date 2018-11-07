using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Store;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Store
{
    public interface IStoreService
    {
        Task StoreChannel(StoreChannel channel);
    }
}