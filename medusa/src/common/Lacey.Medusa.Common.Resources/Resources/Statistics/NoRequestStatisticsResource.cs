using System.Collections.Generic;

namespace Lacey.Medusa.Common.Resources.Resources.Statistics
{
    public class NoRequestStatisticsResource<TData> : StatisticsResource<EmptyStatisticsRequestResource, TData>
    {
        public NoRequestStatisticsResource()
        {            
        }

        public NoRequestStatisticsResource(IEnumerable<StatisticsItemResource<TData>> items)
            : base(new EmptyStatisticsRequestResource(), items)
        {
        }
    }
}