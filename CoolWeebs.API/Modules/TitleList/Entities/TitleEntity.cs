using CoolWeebs.API.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolWeebs.API.Modules.TitleList.Entities
{
    [Table(name: "tb_tl_title")]
    public class TitleEntity : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id")]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(name: "title")]
        public string? Title { get; set; }

        [MaxLength(200)]
        [Column(name: "url_thumbnail")]
        public string? UrlThumbnail { get; set; }

        [Column(name: "description")]
        public string? Description { get; set; }
    }
}
