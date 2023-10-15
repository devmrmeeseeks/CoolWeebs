using CoolWeebs.API.Database;
using CoolWeebs.API.Database.Repository;
using CoolWeebs.API.Modules.TitleList.Entities;

namespace CoolWeebs.API.Modules.TitleList.Repositories
{
    public class ItemRepository : BaseRepository<ItemEntity, long>, IItemRepository
    {
        public ItemRepository(BaseContext context) : base(context)
        {
        }
    }
}
