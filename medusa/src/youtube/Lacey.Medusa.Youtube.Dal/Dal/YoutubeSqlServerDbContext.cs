using Microsoft.EntityFrameworkCore;

namespace Lacey.Medusa.Youtube.Dal.Dal
{
    public class YoutubeSqlServerDbContext : YoutubeDbContext
    {
        public YoutubeSqlServerDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public YoutubeSqlServerDbContext(DbContextOptions options)
            : base(options)
        {            
        }
    }
}