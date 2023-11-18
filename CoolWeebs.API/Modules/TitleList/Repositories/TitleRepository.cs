using CoolWeebs.API.Database;
using CoolWeebs.API.Database.Repository;
using CoolWeebs.API.Modules.TitleList.Entities;

namespace CoolWeebs.API.Modules.TitleList.Repositories
{
    public class TitleRepository : BaseRepository<TitleEntity, long>, ITitleRepository
    {
        public TitleRepository(BaseContext context) : base(context)
        {
        }
    }
}
