using CoolWeebs.API.Database;
using CoolWeebs.API.Database.Repository;
using CoolWeebs.API.Modules.TitleList.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoolWeebs.API.Modules.TitleList.Repositories
{
    public class ItemRepository : BaseRepository<ItemEntity, long>, IItemRepository
    {
        private readonly BaseContext _context;

        public ItemRepository(BaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemEntity>> GetAllByListAsync(long listId, CancellationToken cancellationToken)
        {
            return await _context.Set<ItemEntity>()
                .Include(t => t.Title)
                .Where(s => s.ListId.Equals(listId) && !s.IsDeleted)
                .ToListAsync(cancellationToken);
        }
    }
}
