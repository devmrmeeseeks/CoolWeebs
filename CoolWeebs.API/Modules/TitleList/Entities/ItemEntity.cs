using CoolWeebs.API.Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolWeebs.API.Modules.TitleList.Entities
{
    [Table(name: "tb_tl_item")]
    [Index(nameof(Id), nameof(TitleId), nameof(ListId), nameof(CreatedAt))]
    public class ItemEntity : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id")]
        public long Id { get; set; }

        [Column(name: "is_completed")]
        public bool IsCompleted { get; set; }

        [Column(name: "tl_title_id")]
        [ForeignKey(name: "tl_title_id")]
        public long? TitleId { get; set; }

        [Column(name: "tl_list_id")]
        [ForeignKey(name: "tl_list_id")]
        public long ListId { get; set; }

        public virtual ListEntity? List { get; set; }
        public virtual TitleEntity? Title { get; set; }
    }
}
