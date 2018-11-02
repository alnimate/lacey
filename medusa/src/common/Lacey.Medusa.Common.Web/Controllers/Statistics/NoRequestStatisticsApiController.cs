using AutoMapper;
using Lacey.Medusa.Common.Resources.Resources.Statistics;
using Lacey.Medusa.Common.Services.Models.Statistics;
using Lacey.Medusa.Common.Services.Services.Statistics.Interfaces;

namespace Lacey.Medusa.Common.Web.Controllers.Statistics
{
    public abstract class NoRequestStatisticsApiController<TService, TData>
        : StatisticsApiController<TService, EmptyStatisticsRequest, EmptyStatisticsRequestResource, TData>
        where TService : IStatisticsService<EmptyStatisticsRequest, TData>
    {
        protected NoRequestStatisticsApiController(TService service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}