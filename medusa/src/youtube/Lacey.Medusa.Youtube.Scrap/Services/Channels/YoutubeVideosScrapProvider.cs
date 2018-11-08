using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Common.Interfaces;
using Lacey.Medusa.Youtube.Common.Models;
using Lacey.Medusa.Youtube.Scrap.Services.Common;

namespace Lacey.Medusa.Youtube.Scrap.Services.Channels
{
    public sealed class YoutubeVideosScrapProvider : YoutubeScrapService, IYoutubeVideosProvider
    {
        public async Task<IEnumerable<YoutubeVideo>> GetYoutubeVideos(string channelId)
        {
            return new List<YoutubeVideo>();
        }
    }
}