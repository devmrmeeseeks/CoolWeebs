using CoolWeebs.API.Common.Repository;
using CoolWeebs.API.Modules.TitleList.Entities;

namespace CoolWeebs.API.Modules.TitleList.Repositories
{
    public interface ITitleRepository : IBaseRepository<TitleEntity, long>
    {
    }
}
