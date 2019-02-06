using Lacey.Medusa.Instagram.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lacey.Medusa.Instagram.Dal.EntityConfigurations
{
    internal sealed class MediaConfiguration : IEntityTypeConfiguration<MediaEntity>
    {
        public void Configure(EntityTypeBuilder<MediaEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.MediaId).HasMaxLength(50).IsRequired();
            builder.Property(e => e.OriginalMediaId).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Name).HasColumnName("Title").IsRequired(false);
            builder.Property(e => e.Description).IsRequired(false);
            builder.Property(e => e.PublishedAt).IsRequired(false);
            builder.Property(e => e.CreatedAt).HasDefaultValue().IsRequired();
            builder.Property(e => e.ChannelId).IsRequired();

            builder.HasOne(e => e.Channel)                
                .WithMany(e => e.Medias)
                .HasForeignKey(e => e.ChannelId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Medias");
        }
    }
}