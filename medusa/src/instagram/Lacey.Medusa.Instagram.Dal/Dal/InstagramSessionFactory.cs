using Lacey.Medusa.Common.Dal.Dal;

namespace Lacey.Medusa.Instagram.Dal.Dal
{
    public class InstagramSessionFactory : ISessionFactory
    {
        private readonly string connectionString;

        public InstagramSessionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbContext GetSession()
        {
            return new InstagramSqlServerDbContext(this.connectionString);
        }

        public IDbContext GetSession(string conString)
        {
            return new InstagramSqlServerDbContext(conString);
        }

        public IDbContext GetSessionWithDisabledLazyLoading()
        {
            var session = new InstagramSqlServerDbContext(this.connectionString);
            return session;
        }

        public IDbContext GetSessionWithDisabledLazyLoading(string conString)
        {
            var session = new InstagramSqlServerDbContext(conString);
            return session;
        }
    }
}