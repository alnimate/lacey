using System.Threading.Tasks;

namespace Lacey.Medusa.Instagram.Services.Transfer.Services
{
    public interface ITransferService
    {
        #region Apply metadata

        Task ApplyMediaMetadataLast(string sourceChannelId, string destChannelId);

        Task ApplyMediaMetadataAll(string sourceChannelId, string destChannelId);

        #endregion

        #region Transfer media

        Task TransferMediaLast(string sourceChannelId, string destChannelId);

        Task TransferMedia(string sourceChannelId, string destChannelId);

        #endregion

        #region Save media

        Task SaveMedia(string sourceChannelId, string destChannelId);

        Task UploadMedia(string sourceChannelId, string destChannelId);

        #endregion
    }
}