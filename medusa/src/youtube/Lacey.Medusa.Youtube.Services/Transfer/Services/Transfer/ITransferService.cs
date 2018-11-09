using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Services.Store.Events;
using Lacey.Medusa.Youtube.Services.Transfer.Events.Download;
using Lacey.Medusa.Youtube.Services.Transfer.Events.Upload;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Transfer
{
    public interface ITransferService
    {
        Task TransferChannel(string sourceChannelId, string destChannelId);

        event DownloadChannelDelegate OnDownloadChannel;

        event StoreChannelDelegate OnStoreChannel;

        event UploadChannelDelegate OnUploadChannel;
    }
}