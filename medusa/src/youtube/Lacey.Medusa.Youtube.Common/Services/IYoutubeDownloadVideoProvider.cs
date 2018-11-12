using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Common.Models.Videos;

namespace Lacey.Medusa.Youtube.Common.Services
{
    public interface IYoutubeDownloadVideoProvider
    {
        Task<YoutubeVideoFile> DownloadVideo(string videoId);
    }
}