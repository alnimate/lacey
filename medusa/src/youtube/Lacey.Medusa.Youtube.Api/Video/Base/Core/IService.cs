using System.Collections.Generic;

namespace Lacey.Medusa.Youtube.Api.Video.Base.Core
{
    internal interface IService<T> where T : Video
    {
        T GetVideo(string uri);
        IEnumerable<T> GetAllVideos(string uri);
    }
}
