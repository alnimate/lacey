using System.Collections.Generic;
using Lacey.Medusa.Youtube.Api.Models.Videos;

namespace Lacey.Medusa.Youtube.Api.Services.Videos
{
    public interface IVideosService
    {
        IEnumerable<Video> GetChannelVideos(string channelId);
    }
}