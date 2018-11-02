using System.Collections.Generic;

namespace Lacey.Medusa.Common.Resources.Resources.Statistics
{
    public class IntStatisticsResource<TRequest> : StatisticsResource<TRequest, int>
    {
        public IntStatisticsResource()
        {            
        }

        public IntStatisticsResource(TRequest request, IEnumerable<StatisticsItemResource<int>> items)
            : base(request, items)
        {
        }
    }
}