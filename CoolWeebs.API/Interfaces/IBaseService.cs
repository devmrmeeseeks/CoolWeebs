using CoolWebs.Model.TitleLIst;
using LanguageExt.Common;

namespace CoolWeebs.API.Interfaces
{
    public interface IBaseService<TResponse, TRequest, IType> where TResponse : class where TRequest : class
    {
        Task<Result<TResponse>> CreateAsync(TRequest request, CancellationToken cancellationToken);
        Task<Result<TResponse>> GetByIdAsync(IType id, CancellationToken cancellationToken);
        Task<Result<TResponse>> UpdateAsync(IType id, TRequest request, CancellationToken cancellationToken);
        Task<Result<bool>> DeleteAsync(IType id, CancellationToken cancellationToken);
    }
}
