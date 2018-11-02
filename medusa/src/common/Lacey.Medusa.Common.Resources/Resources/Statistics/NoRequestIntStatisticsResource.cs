using System.Collections.Generic;

namespace Lacey.Medusa.Common.Resources.Resources.Statistics
{
    public class NoRequestIntStatisticsResource : StatisticsResource<EmptyStatisticsRequestResource, int>
    {
        public NoRequestIntStatisticsResource()
        {            
        }

        public NoRequestIntStatisticsResource(
            EmptyStatisticsRequestResource request, IEnumerable<StatisticsItemResource<int>> items)
            : base(request, items)
        {
        }
    }
}