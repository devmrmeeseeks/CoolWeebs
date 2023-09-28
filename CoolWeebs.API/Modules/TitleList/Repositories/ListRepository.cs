using CoolWeebs.API.Common.Repository;
using CoolWeebs.API.Database;
using CoolWeebs.API.Modules.TitleList.Entities;

namespace CoolWeebs.API.Modules.TitleList.Repositories
{
    public class ListRepository : BaseRepository<ListEntity, long>, IListRepository
    {
        public ListRepository(BaseContext context) : base(context)
        {
        }   
    }
}
