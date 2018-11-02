namespace Lacey.Medusa.Common.Services.Services.Entity.Interfaces
{
    using Models.Business;

    public interface ILongIdEntityService<TModel, in TOverviewsRequest, TOverviews>
        : IEntityService<TModel, long, TOverviewsRequest, TOverviews>
        where TModel : LongIdBusinessModel
    {
    }
}