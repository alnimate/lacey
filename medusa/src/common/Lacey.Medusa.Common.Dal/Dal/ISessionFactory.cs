namespace Lacey.Medusa.Common.Dal.Dal
{
    public interface ISessionFactory
    {
        IDbContext GetSession();

        IDbContext GetSession(string connectionString);

        IDbContext GetSessionWithDisabledLazyLoading();

        IDbContext GetSessionWithDisabledLazyLoading(string connectionString);
    }
}