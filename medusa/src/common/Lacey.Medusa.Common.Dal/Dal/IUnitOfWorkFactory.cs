namespace Lacey.Medusa.Common.Dal.Dal
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();

        IUnitOfWork Create(string connectionString);

        IUnitOfWork CreateWithDisabledLazyLoading();

        IUnitOfWork CreateWithDisabledLazyLoading(string connectionString);
    }
}