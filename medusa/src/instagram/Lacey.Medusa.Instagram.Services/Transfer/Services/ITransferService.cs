using System.Threading.Tasks;

namespace Lacey.Medusa.Instagram.Services.Transfer.Services
{
    public interface ITransferService
    {
        Task SaveMedia(string sourceChannelId, string destChannelId);

        Task UploadMedia(string sourceChannelId, string destChannelId);

        Task TransferMediaLast(string sourceChannelId, string destChannelId);

        Task TransferMedia(string sourceChannelId, string destChannelId);
    }
}