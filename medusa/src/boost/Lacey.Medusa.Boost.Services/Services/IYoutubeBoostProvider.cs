using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Base;

namespace Lacey.Medusa.Boost.Services.Services
{
    public interface IYoutubeBoostProvider
    {
        Task<IReadOnlyList<SearchResult>> FindVideosByTags(string[] tags);

        Task<Video> GetVideo(string videoId);
    }
}