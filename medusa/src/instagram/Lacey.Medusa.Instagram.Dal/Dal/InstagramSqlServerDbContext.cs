using Microsoft.EntityFrameworkCore;

namespace Lacey.Medusa.Instagram.Dal.Dal
{
    public class InstagramSqlServerDbContext : InstagramDbContext
    {
        public InstagramSqlServerDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public InstagramSqlServerDbContext(DbContextOptions options)
            : base(options)
        {            
        }
    }
}