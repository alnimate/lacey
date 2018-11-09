using System.Threading.Tasks;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services
{
    public interface ITransferService
    {
        Task TransferChannel(string sourceChannelId, string destChannelId);
    }
}