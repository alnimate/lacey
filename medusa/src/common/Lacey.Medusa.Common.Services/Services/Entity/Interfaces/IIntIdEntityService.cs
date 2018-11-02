namespace Lacey.Medusa.Common.Services.Services.Entity.Interfaces
{
    using Models.Business;

    public interface IIntIdEntityService<TModel, in TOverviewsRequest, TOverviews>
        : IEntityService<TModel, int, TOverviewsRequest, TOverviews>
        where TModel : IntIdBusinessModel
    {
    }
}