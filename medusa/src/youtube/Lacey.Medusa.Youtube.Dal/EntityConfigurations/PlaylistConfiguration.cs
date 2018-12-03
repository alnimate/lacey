using Lacey.Medusa.Youtube.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lacey.Medusa.Youtube.Dal.EntityConfigurations
{
    internal sealed class PlaylistConfiguration : IEntityTypeConfiguration<PlaylistEntity>
    {
        public void Configure(EntityTypeBuilder<PlaylistEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.PlaylistId).HasMaxLength(30).IsRequired();
            builder.Property(e => e.OriginalPlaylistId).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Name).HasColumnName("Title").IsRequired();
            builder.Property(e => e.Description).IsRequired(false);
            builder.Property(e => e.PublishedAt).IsRequired();
            builder.Property(e => e.CreatedAt).HasDefaultValue().IsRequired();
            builder.Property(e => e.ChannelId).IsRequired();

            builder.HasOne(e => e.Channel)
                .WithMany(e => e.Playlists)
                .HasForeignKey(e => e.ChannelId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Playlists");
        }
    }
}