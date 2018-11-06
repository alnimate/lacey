using System.Collections.Generic;
using Lacey.Medusa.Youtube.Services.Api.Models.Videos;

namespace Lacey.Medusa.Youtube.Services.Api.Services.Videos
{
    public interface IYoutubeVideosService
    {
        IEnumerable<YoutubeVideo> GetChannelVideos(string channelId);
    }
}