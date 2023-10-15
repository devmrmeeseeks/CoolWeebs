using CoolWebs.Model.TitleLIst;
using CoolWeebs.API.Interfaces;
using LanguageExt.Common;

namespace CoolWeebs.API.Modules.TitleList.Services
{
    public interface ITitleService : IBaseService<TitleResponse, TitleRequest, long>
    {
        Task<Result<IEnumerable<TitleResponse>>> GetByNameAsync(string name, CancellationToken cancellationToken);
    }
}
