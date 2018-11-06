using System.Collections.Generic;
using Lacey.Medusa.Common.Services.Models.Overviews;

namespace Lacey.Medusa.Youtube.Services.Database.Models.Channels.Overviews
{
    public sealed class ChannelOverviews : OverviewsModel<ChannelOverviewsRequest, ChannelOverview>
    {
        public ChannelOverviews(
            ChannelOverviewsRequest request, 
            int recordsCount, 
            IEnumerable<ChannelOverview> overviews)
            : base(request, recordsCount, overviews)
        {
        }
    }
}