using Lacey.Medusa.Youtube.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lacey.Medusa.Youtube.Dal.EntityConfigurations
{
    internal sealed class VideoConfiguration : IEntityTypeConfiguration<VideoEntity>
    {
        public void Configure(EntityTypeBuilder<VideoEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.VideoId).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Name).HasColumnName("Title").IsRequired();
            builder.Property(e => e.Description).IsRequired(false);
            builder.Property(e => e.PublishedAt).IsRequired();
            builder.Property(e => e.CreatedAt).HasDefaultValue().IsRequired();
            builder.Property(e => e.ChannelId).IsRequired();

            builder.HasOne(e => e.Channel)                
                .WithMany(e => e.Videos)
                .HasForeignKey(e => e.ChannelId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Videos");
        }
    }
}