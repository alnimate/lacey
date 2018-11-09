using System.Collections.Generic;

namespace Lacey.Medusa.Youtube.Common.Models.Videos
{
    public sealed class YoutubeVideos
    {
        public YoutubeVideos(IEnumerable<YoutubeVideo> videos)
        {
            Videos = videos;
        }

        public IEnumerable<YoutubeVideo> Videos { get; }
    }
}