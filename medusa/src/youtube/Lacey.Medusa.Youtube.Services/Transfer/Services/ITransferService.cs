﻿using System.Threading.Tasks;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services
{
    public interface ITransferService
    {
        Task TransferChannel(string sourceChannelId, string destChannelId);

        Task SetThumbnails(string sourceChannelId, string destChannelId);

        Task TransferMetadata(string sourceChannelId, string destChannelId);

        Task TransferVideos(string sourceChannelId, string destChannelId);

        Task TransferPlaylists(string sourceChannelId, string destChannelId);

        Task TransferSections(string sourceChannelId, string destChannelId);

        Task TransferSubscriptions(string sourceChannelId, string destChannelId);
    }
}