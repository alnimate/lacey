using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services
{
    public interface ITransferService
    {
        Task TransferVideosLast(
            string sourceChannelId,
            string destChannelId,
            Dictionary<string, string> replacements);

        Task SetThumbnailsLast(string sourceChannelId, string destChannelId);

        Task TransferChannel(string sourceChannelId, string destChannelId);

        Task SetThumbnails(string sourceChannelId, string destChannelId);

        Task TransferMetadata(string sourceChannelId, string destChannelId);

        Task TransferVideos(string sourceChannelId, string destChannelId);

        Task TransferPlaylists(string sourceChannelId, string destChannelId);

        Task TransferSections(string sourceChannelId, string destChannelId);

        Task TransferSubscriptions(string sourceChannelId, string destChannelId);

        Task UpdateInstagram(string channelId, string originalInstagram, string newInstagram);
    }
}