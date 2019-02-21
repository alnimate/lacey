using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services
{
    public interface ITransferService
    {
        Task UpdateVideos(
            string sourceChannelId,
            string destChannelId,
            Dictionary<string, string> replacements);

        Task SetThumbnailsLast(string sourceChannelId, string destChannelId);

        Task TransferChannel(string sourceChannelId, string destChannelId);

        Task SetThumbnails(string sourceChannelId, string destChannelId);

        Task TransferMetadata(
            string sourceChannelId, 
            string destChannelId, 
            bool downloadIcon = false,
            Dictionary<string, string> replacements = null);

        Task TransferVideos(string sourceChannelId, string destChannelId);

        Task TransferPlaylists(string sourceChannelId, string destChannelId, bool onlyLast);

        Task TransferSections(string sourceChannelId, string destChannelId);

        Task TransferSubscriptions(string sourceChannelId, string destChannelId);

        Task UpdateInstagram(string channelId, string originalInstagram, string newInstagram);
    }
}