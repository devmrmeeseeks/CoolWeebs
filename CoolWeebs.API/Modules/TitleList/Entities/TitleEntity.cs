using CoolWeebs.API.Database.Entity;

namespace CoolWeebs.API.Modules.TitleList.Entities
{
    public class TitleEntity : AuditEntity, IEntity<long>
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string? UrlThumbnail { get; set; }

        public string? Description { get; set; }
    }
}
