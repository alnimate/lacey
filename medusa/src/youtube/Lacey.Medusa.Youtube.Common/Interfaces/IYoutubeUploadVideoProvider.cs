using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Common.Models.Videos;

namespace Lacey.Medusa.Youtube.Common.Interfaces
{
    public interface IYoutubeUploadVideoProvider
    {
        Task UploadVideo(string channelId, YoutubeVideo youtubeVideo, string filePath);
    }
}