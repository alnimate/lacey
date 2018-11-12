using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lacey.Medusa.Youtube.Common.Video.Base.Core
{
    internal interface IAsyncService<T> where T : Video
    {
        Task<T> GetVideoAsync(string uri);
        Task<IEnumerable<T>> GetAllVideosAsync(string uri);
    }
}
