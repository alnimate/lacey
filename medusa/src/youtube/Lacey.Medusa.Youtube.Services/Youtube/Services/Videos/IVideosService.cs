using Lacey.Medusa.Common.Services.Services.Entity.Interfaces;
using Lacey.Medusa.Youtube.Services.Youtube.Models.Videos.Entity;
using Lacey.Medusa.Youtube.Services.Youtube.Models.Videos.Overviews;

namespace Lacey.Medusa.Youtube.Services.Youtube.Services.Videos
{
    public interface IVideosService
        : IIntIdEntityService<Video, VideoOverviewsRequest, VideoOverviews>
    {
    }
}