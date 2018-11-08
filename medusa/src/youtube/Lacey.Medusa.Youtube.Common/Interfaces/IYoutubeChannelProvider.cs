using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Common.Models;

namespace Lacey.Medusa.Youtube.Common.Interfaces
{
    public interface IYoutubeChannelProvider
    {
        Task<YoutubeChannel> GetYoutubeChannel(string channelId);
    }
}