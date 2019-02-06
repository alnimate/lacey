using Lacey.Medusa.Common.Dal.Dal.Concrete;
using Lacey.Medusa.Instagram.Dal.EntityConfigurations;
using Lacey.Medusa.Instagram.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lacey.Medusa.Instagram.Dal.Dal
{
    public class InstagramDbContext : DatabaseContext
    {
        public InstagramDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public InstagramDbContext(DbContextOptions options)
            : base(options)
        {            
        }

        public DbSet<ChannelEntity> Channels { get; set; }   

        public DbSet<MediaEntity> Medias { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChannelConfiguration());
            modelBuilder.ApplyConfiguration(new MediaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}