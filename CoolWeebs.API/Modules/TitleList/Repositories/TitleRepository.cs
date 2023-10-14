using CoolWeebs.API.Database;
using CoolWeebs.API.Database.Repository;
using CoolWeebs.API.Modules.TitleList.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoolWeebs.API.Modules.TitleList.Repositories
{
    public class TitleRepository : BaseRepository<TitleEntity, long>, ITitleRepository
    {
        private readonly BaseContext _context;
        public TitleRepository(BaseContext context) : base(context)
        {
            _context = context;
        }
    }
}
