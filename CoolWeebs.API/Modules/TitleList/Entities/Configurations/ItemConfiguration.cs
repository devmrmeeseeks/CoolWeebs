using CoolWeebs.API.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoolWeebs.API.Modules.TitleList.Entities.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<ItemEntity>
    {
        public void Configure(EntityTypeBuilder<ItemEntity> builder)
        {
            builder.ToTable("tb_tl_item")
                .HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.TitleId)
                .HasColumnName("title_id")
                .IsRequired();

            builder.Property(e => e.ListId)
                .HasColumnName("list_id")
                .IsRequired();

            builder.Property(e => e.IsCompleted)
                .HasColumnName("is_completed")
                .HasDefaultValue(false);

            builder.HasIndex(e => new { e.Id, e.TitleId, e.ListId });
            builder.HasIndex(e => new { e.ListId, e.TitleId }).IsUnique();

            builder.ConfigureCommonProperties();
        }
    }
}
