using CoolWeebs.API.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolWeebs.API.Modules.TitleList.Entities
{
    public class ItemEntity : AuditEntity, IEntity<long>
    {
        public long Id { get; set; }

        public bool IsCompleted { get; set; }

        public long? TitleId { get; set; }

        public long ListId { get; set; }

        public virtual ListEntity? List { get; set; }
        public virtual TitleEntity? Title { get; set; }
    }
}
