using CoolWeebs.API.Common.Repository;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolWeebs.API.Modules.TitleList.Entities
{
    [Table(name: "tb_tl_list")]
    [Index(nameof(Id), nameof(Title), nameof(CreatedAt))]
    public class ListEntity : AuditEntity, IEntity<long>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id")]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(name: "title")]
        public string Title { get; set; } = null!;

        [MaxLength(200)]
        [Column(name: "url_thumbnail")]
        public string? UrlThumbnail { get; set; }

        [MaxLength(500)]
        [Column(name: "description")]
        public string? Description { get; set; }

        public virtual ICollection<ItemEntity>? Items { get; set; }
    }
}
