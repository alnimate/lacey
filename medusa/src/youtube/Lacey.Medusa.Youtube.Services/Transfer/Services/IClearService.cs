using System.Threading.Tasks;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services
{
    public interface IClearService
    {
        Task ClearChannel(string channelId);
    }
}