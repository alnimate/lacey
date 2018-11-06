using Lacey.Medusa.Common.Services.Services.Entity.Interfaces;
using Lacey.Medusa.Youtube.Services.Management.Models.Videos.Entity;
using Lacey.Medusa.Youtube.Services.Management.Models.Videos.Overviews;

namespace Lacey.Medusa.Youtube.Services.Management.Services.Videos
{
    public interface IVideoEntityService
        : IIntIdEntityService<Video, VideoOverviewsRequest, VideoOverviews>
    {
    }
}