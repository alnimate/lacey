using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Common.Models;

namespace Lacey.Medusa.Youtube.Common.Interfaces
{
    public interface IYoutubeVideosProvider
    {
        Task<IEnumerable<YoutubeVideo>> GetYoutubeVideos(string channelId);
    }
}