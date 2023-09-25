using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolWeebs.API.Database
{
    public class AuditEntity
    {
        [DefaultDateTime]
        [Column(name: "created_at")]
        public DateTime CreatedAt { get; set; }

        [Column(name: "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [DefaultValue("true")]
        [Column(name: "is_deleted")]
        public bool IsDeleted { get; set; } = false;

        [Column(name: "deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }

    public class DefaultDateTimeAttribute : DefaultValueAttribute
    {
        public DefaultDateTimeAttribute() : base(DateTime.UtcNow)
        {
        }
    }
}
