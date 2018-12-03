using Lacey.Medusa.Common.Dal.Dal.Concrete;
using Lacey.Medusa.Youtube.Dal.EntityConfigurations;
using Lacey.Medusa.Youtube.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lacey.Medusa.Youtube.Dal.Dal
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

        public DbSet<PlaylistEntity> Playlists { get; set; }   

        public DbSet<PlaylistVideoEntity> PlaylistsVideos { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChannelConfiguration());
            modelBuilder.ApplyConfiguration(new VideoConfiguration());
            modelBuilder.ApplyConfiguration(new PlaylistConfiguration());
            modelBuilder.ApplyConfiguration(new PlaylistVideoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}