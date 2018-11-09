using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Services.Store.Models;

namespace Lacey.Medusa.Youtube.Services.Store.Services
{
    public interface IStoreService
    {
        Task StoreChannel(StoreChannel channel);
    }
}