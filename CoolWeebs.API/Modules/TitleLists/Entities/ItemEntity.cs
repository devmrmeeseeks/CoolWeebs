using CoolWeebs.API.Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolWeebs.API.Modules.List.Entities
{
    [Table(name: "tb_tl_item")]
    [Index(nameof(Id), nameof(Title), nameof(CreatedAt))]
    public class ItemEntity : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id")]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(name: "title")]
        public string? Title { get; set; } = null!;

        [MaxLength(200)]
        [Column(name: "url_thumbnail")]
        public string? UrlThumbnail { get; set; }

        [Column(name: "is_completed")]
        public bool IsCompleted { get; set; }

        [Required]
        [Column(name: "tl_list_id")]
        [ForeignKey(name: "tl_list_id")]
        public long TitleListId { get; set; }

        public virtual TitleListEntity? TitleList { get; set; }
    }
}
