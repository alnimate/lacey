using System.Threading.Tasks;
using AutoMapper;
using Lacey.Medusa.Youtube.Services.Store.Events;
using Lacey.Medusa.Youtube.Services.Store.Models;
using Lacey.Medusa.Youtube.Services.Transfer.Events.Download;
using Lacey.Medusa.Youtube.Services.Transfer.Events.Upload;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Download;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Download;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Upload;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Transfer.Concrete
{
    public sealed class TransferService : ITransferService
    {
        private readonly IMapper mapper;

        private readonly IDownloadService downloadService;
        
        private readonly IUploadService uploadService;

        public event DownloadChannelDelegate OnDownloadChannel;

        public event StoreChannelDelegate OnStoreChannel;

        public event UploadChannelDelegate OnUploadChannel;

        public TransferService(
            IMapper mapper, 
            IDownloadService downloadService, 
            IUploadService uploadService)
        {
            this.mapper = mapper;
            this.downloadService = downloadService;
            this.uploadService = uploadService;
        }

        public async Task TransferChannel(string sourceChannelId, string destChannelId)
        {
            var downloadChannel = await this.downloadService.DownloadChannel(sourceChannelId);
            this.DoDownloadChannel(downloadChannel);
        }

        private void DoDownloadChannel(DownloadChannel channel)
        {
            OnDownloadChannel?.Invoke(channel);
        }

        private void DoUploadChannel(StoreChannel channel)
        {
            OnStoreChannel?.Invoke(channel);
        }
    }
}