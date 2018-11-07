using Lacey.Medusa.Youtube.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lacey.Medusa.Youtube.Dal.EntityConfigurations
{
    internal sealed class ChannelConfiguration : IEntityTypeConfiguration<ChannelEntity>
    {
        public void Configure(EntityTypeBuilder<ChannelEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ChannelId).HasMaxLength(30).IsRequired(false);
            builder.Property(e => e.Name).HasColumnName("Title").IsRequired(false);
            builder.Property(e => e.Description).IsRequired(false);
            builder.Property(e => e.CreatedAt).IsRequired();

            builder.ToTable("Channels");
        }
    }
}