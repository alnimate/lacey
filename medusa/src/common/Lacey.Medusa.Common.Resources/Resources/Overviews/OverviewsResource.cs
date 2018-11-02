using System.Collections.Generic;
using Lacey.Medusa.Common.DataAnnotations.Attributes.Numbers;

namespace Lacey.Medusa.Common.Resources.Resources.Overviews
{
    public abstract class OverviewsResource<TRequest, TOverview>
    {
        protected OverviewsResource()
        {            
        }

        protected OverviewsResource(
            TRequest request,
            int recordsCount,
            IEnumerable<TOverview> overviews)
        {
            this.Request = request;
            this.RecordsCount = recordsCount;
            this.Overviews = overviews;
        }

        public TRequest Request { get; set; }

        [MinIntValue(0)]
        public int RecordsCount { get; set; }

        public IEnumerable<TOverview> Overviews { get; set; }
    }
}