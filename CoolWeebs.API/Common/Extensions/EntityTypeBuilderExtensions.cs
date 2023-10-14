using CoolWeebs.API.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoolWeebs.API.Common.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static void ConfigureCommonProperties<T>(this EntityTypeBuilder<T> builder) where T : AuditEntity
        {
            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(e => e.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValue(false);

            builder.HasIndex(s => new { s.IsDeleted, s.CreatedAt, s.UpdatedAt });
        }
    }
}
