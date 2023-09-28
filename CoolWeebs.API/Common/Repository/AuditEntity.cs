using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolWeebs.API.Common.Repository
{
    public class AuditEntity
    {
        [Column(name: "created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column(name: "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [DefaultValue("true")]
        [Column(name: "is_deleted")]
        public bool IsDeleted { get; set; }

        [Column(name: "deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
