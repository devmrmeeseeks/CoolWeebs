using CoolWeebs.API.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolWeebs.API.Modules.TitleList.Entities
{
    public class ListEntity : AuditEntity, IEntity<long>
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string? UrlThumbnail { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<ItemEntity>? Items { get; set; }
    }
}
