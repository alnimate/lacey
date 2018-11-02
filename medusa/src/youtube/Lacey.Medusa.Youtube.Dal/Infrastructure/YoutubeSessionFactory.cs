using Lacey.Medusa.Common.Dal.Infrastructure;

namespace Lacey.Medusa.Youtube.Dal.Infrastructure
{
    public class YoutubeSessionFactory : ISessionFactory
    {
        private readonly string connectionString;

        public YoutubeSessionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbContext GetSession()
        {
            return new YoutubeSqlServerDbContext(this.connectionString);
        }

        public IDbContext GetSession(string conString)
        {
            return new YoutubeSqlServerDbContext(conString);
        }

        public IDbContext GetSessionWithDisabledLazyLoading()
        {
            var session = new YoutubeSqlServerDbContext(this.connectionString);
            return session;
        }

        public IDbContext GetSessionWithDisabledLazyLoading(string conString)
        {
            var session = new YoutubeSqlServerDbContext(conString);
            return session;
        }
    }
}