using Lacey.Medusa.Youtube.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lacey.Medusa.Youtube.Dal.EntityConfigurations
{
    internal sealed class PlaylistVideoConfiguration : IEntityTypeConfiguration<PlaylistVideoEntity>
    {
        public void Configure(EntityTypeBuilder<PlaylistVideoEntity> builder)
        {
            builder.HasKey(e => new { e.PlaylistId, e.VideoId });

            builder.HasOne(e => e.Playlist)
                .WithMany(e => e.PlaylistVideos)
                .HasForeignKey(e => e.PlaylistId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Video)
                .WithMany(e => e.PlaylistVideos)
                .HasForeignKey(e => e.VideoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("PlaylistsVideos");
        }
    }
}