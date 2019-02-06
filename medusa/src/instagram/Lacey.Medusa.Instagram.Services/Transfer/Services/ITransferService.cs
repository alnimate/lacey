using System.Threading.Tasks;

namespace Lacey.Medusa.Instagram.Services.Transfer.Services
{
    public interface ITransferService
    {
        Task SaveAllMedia(string sourceChannelId, string destChannelId);

        Task TransferAllMedia(string sourceChannelId, string destChannelId);
    }
}