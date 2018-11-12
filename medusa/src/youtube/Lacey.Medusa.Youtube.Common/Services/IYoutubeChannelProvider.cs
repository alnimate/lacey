using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Common.Models.Common;
using Lacey.Medusa.Youtube.Common.Models.Videos;

namespace Lacey.Medusa.Youtube.Common.Services
{
    public interface IYoutubeChannelProvider
    {
        Task<YoutubeChannel> GetYoutubeChannel(string channelId);

        Task<YoutubeVideos> GetChannelVideos(string channelId);
    }
}