using System.Collections.Generic;
using Lacey.Medusa.Common.Services.Models.Overviews;

namespace Lacey.Medusa.Youtube.Services.Database.Models.Videos.Overviews
{
    public sealed class VideoOverviews : OverviewsModel<VideoOverviewsRequest, VideoOverview>
    {
        public VideoOverviews(
            VideoOverviewsRequest request, 
            int recordsCount, 
            IEnumerable<VideoOverview> overviews)
            : base(request, recordsCount, overviews)
        {
        }
    }
}