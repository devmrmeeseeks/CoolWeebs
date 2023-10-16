using CoolWebs.Model.TitleLIst;
using LanguageExt.Common;

namespace CoolWeebs.API.Modules.TitleList.Services
{
    public interface IListService
    {
        Task<Result<ListResponse>> CreateAsync(ListRequest request, CancellationToken cancellationToken);
        Task<Result<ListResponse>> GetByIdAsync(long id, CancellationToken cancellationToken);
        Task<Result<IEnumerable<ListResponse>>> GetByNameAsync(string name, CancellationToken cancellationToken);
        Task<Result<ListResponse>> UpdateAsync(long id, ListRequest request, CancellationToken cancellationToken);
        Task<Result<bool>> DeleteAsync(long id, CancellationToken cancellationToken);
    }
}
