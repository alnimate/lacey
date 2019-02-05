using System.Threading.Tasks;

namespace Lacey.Medusa.Instagram.Services.Transfer.Services
{
    public interface ITransferService
    {
        Task TransferAllMedia(string sourceChannelId, string destChannelId);
    }
}