using CoolWeebs.API.Database.Repository;
using CoolWeebs.API.Modules.TitleList.Entities;

namespace CoolWeebs.API.Modules.TitleList.Repositories
{
    public interface IItemRepository : IBaseRepository<ItemEntity, long>
    {
        Task<IEnumerable<ItemEntity>> GetAllByListAsync(long listId, CancellationToken cancellationToken);
    }
}
