using System.Collections.Generic;

namespace Lacey.Medusa.Youtube.Common.Models.Videos
{
    public sealed class YoutubeVideos
    {
        public YoutubeVideos(IEnumerable<YoutubeVideo> items)
        {
            Items = items;
        }

        public IEnumerable<YoutubeVideo> Items { get; }
    }
}