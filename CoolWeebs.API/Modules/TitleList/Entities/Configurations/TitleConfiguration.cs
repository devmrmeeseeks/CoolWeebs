using CoolWeebs.API.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoolWeebs.API.Modules.TitleList.Entities.Configurations
{
    public class TitleConfiguration : IEntityTypeConfiguration<TitleEntity>
    {
        public void Configure(EntityTypeBuilder<TitleEntity> builder)
        {
            builder.ToTable("tb_tl_title")
                .HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.UrlThumbnail)
                .HasColumnName("url_thumbnail")
                .HasMaxLength(255);

            builder.Property(e => e.Synopsis)
                .HasColumnName("synopsis");

            builder.Property(e => e.Episodes)
                .HasColumnName("episodes");

            builder.Property(e => e.Year)
                .HasColumnName("year");

            builder.HasIndex(e => new { e.Id, e.Name });

            builder.ConfigureCommonProperties();
        }
    }
}
