using CoolWebs.Model;
using CoolWebs.Model.TitleLIst;
using LanguageExt.Common;

namespace CoolWeebs.API.Modules.TitleList.Services
{
    public interface ITitleService
    {
        Task<Result<TitleResponse>> CreateAsync(TitleRequest request, CancellationToken cancellationToken);
        Task<Result<TitleResponse>> GetByIdAsync(long id, CancellationToken cancellationToken);
        Task<Result<IEnumerable<TitleResponse>>> GetByNameAsync(string name, CancellationToken cancellationToken);
        Task<Result<TitleResponse>> UpdateAsync(long id, TitleRequest reqauest, CancellationToken cancellationToken);
        Task<Result<bool>> DeleteAsync(long id, CancellationToken cancellationToken);
    }
}
