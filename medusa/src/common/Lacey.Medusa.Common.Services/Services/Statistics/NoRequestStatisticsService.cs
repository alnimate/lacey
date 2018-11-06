using Lacey.Medusa.Common.Dal.Dal;

namespace Lacey.Medusa.Common.Services.Services.Statistics
{
    using Lacey.Medusa.Common.Services.Models.Statistics;

    public abstract class NoRequestStatisticsService<TData>
        : StatisticsService<EmptyStatisticsRequest, TData>
    {
        protected NoRequestStatisticsService(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }
    }
}