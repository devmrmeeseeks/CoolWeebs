using CoolWebs.Model.TitleLIst;
using CoolWeebs.API.Database.Repository;
using CoolWeebs.API.Interfaces;
using LanguageExt.Common;

namespace CoolWeebs.API.Modules.TitleList.Services
{
    public interface IListService : IBaseService<ListResponse, ListRequest, long>
    {
        Task<Result<IEnumerable<ListResponse>>> GetByNameAsync(string name, CancellationToken cancellationToken);
    }
}
