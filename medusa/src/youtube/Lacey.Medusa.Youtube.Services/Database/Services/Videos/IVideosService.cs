using Lacey.Medusa.Common.Services.Services.Entity.Interfaces;
using Lacey.Medusa.Youtube.Services.Database.Models.Videos.Entity;
using Lacey.Medusa.Youtube.Services.Database.Models.Videos.Overviews;

namespace Lacey.Medusa.Youtube.Services.Database.Services.Videos
{
    public interface IVideosService
        : IIntIdEntityService<Video, VideoOverviewsRequest, VideoOverviews>
    {
    }
}