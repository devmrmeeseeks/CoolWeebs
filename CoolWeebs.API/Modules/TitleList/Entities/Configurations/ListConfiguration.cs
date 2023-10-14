using CoolWeebs.API.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoolWeebs.API.Modules.TitleList.Entities.Configurations
{
    public class ListConfiguration : IEntityTypeConfiguration<ListEntity>
    {
        public void Configure(EntityTypeBuilder<ListEntity> builder)
        {
            builder.ToTable("tb_tl_list")
                .HasKey(e => e.Id);
            
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.UrlThumbnail)
                .HasColumnName("url_thumbnail")
                .HasMaxLength(200);

            builder.Property(e => e.Description)
                .HasColumnName("description");

            builder.HasIndex(e => new { e.Id, e.Name });

            builder.ConfigureCommonProperties();
        }
    }
}
