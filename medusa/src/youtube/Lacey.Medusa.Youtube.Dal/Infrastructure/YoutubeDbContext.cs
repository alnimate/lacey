using Lacey.Medusa.Common.Dal.Dal.Concrete;
using Lacey.Medusa.Youtube.Dal.EntityConfigurations;
using Lacey.Medusa.Youtube.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lacey.Medusa.Youtube.Dal.Infrastructure
{
    public class YoutubeDbContext : DatabaseContext
    {
        public YoutubeDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public YoutubeDbContext(DbContextOptions options)
            : base(options)
        {            
        }

        public DbSet<ChannelEntity> Channels { get; set; }   

        public DbSet<VideoEntity> Videos { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChannelConfiguration());
            modelBuilder.ApplyConfiguration(new VideoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}