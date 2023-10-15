using CoolWeebs.API.Entities;

namespace CoolWeebs.API.Modules.TitleList.Entities
{
    public class ItemEntity : AuditEntity, IEntity<long>
    {
        public long Id { get; set; }

        public bool IsCompleted { get; set; }

        public long? TitleId { get; set; }

        public long ListId { get; set; }
    }
}
