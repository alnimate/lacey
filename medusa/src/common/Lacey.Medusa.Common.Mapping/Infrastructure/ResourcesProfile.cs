using Lacey.Medusa.Common.Resources.Resources.Lists;
using Lacey.Medusa.Common.Resources.Resources.Statistics;

namespace Lacey.Medusa.Common.Mapping.Infrastructure
{
    using System.Collections.Generic;

    using AutoMapper;

    using Services.Models.Lists;
    using Services.Models.Statistics;

    public class ResourcesProfile : Profile
    {
        public ResourcesProfile()
        {
            // Statistics
            this.CreateMap<EmptyStatisticsRequest, EmptyStatisticsRequestResource>()
                .ConstructUsing(
                    m => new EmptyStatisticsRequestResource());

            this.CreateMap<NoRequestIntStatistics, NoRequestIntStatisticsResource>()
                .ConstructUsing(
                    m => new NoRequestIntStatisticsResource());

            // Lists
            this.CreateMap<ModelItem, ModelItemResource>()
                .ConstructUsing(
                    m => new ModelItemResource(m.Value, m.Text));

            this.CreateMap<EmptyListRequestResource, EmptyListRequest>()
                .ConstructUsing(
                    r => new EmptyListRequest())
                .ReverseMap()
                .ConstructUsing(
                    m => new EmptyListRequestResource());

            this.CreateMap<ModelsList<EmptyListRequest>, ModelsListResource<EmptyListRequestResource>>()
                .ConstructUsing(
                    m => new ModelsListResource<EmptyListRequestResource>(
                        Mapper.Map<EmptyListRequestResource>(m.Request),
                        Mapper.Map<IEnumerable<ModelItemResource>>(m.Items)));

            this.CreateMap<NoRequestModelsList, NoRequestListResource>()
                .ConstructUsing(
                    m => new NoRequestListResource());
        }
    }
}