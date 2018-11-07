using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Download;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Download
{
    public interface IDownloadService
    {
        Task<DownloadChannel> DownloadChannel(string channelId);
    }
}