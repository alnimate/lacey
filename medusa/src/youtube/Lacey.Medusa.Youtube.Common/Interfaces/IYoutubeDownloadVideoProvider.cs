using System.Threading.Tasks;

namespace Lacey.Medusa.Youtube.Common.Interfaces
{
    public interface IYoutubeDownloadVideoProvider
    {
        Task DownloadVideo(string videoId);
    }
}