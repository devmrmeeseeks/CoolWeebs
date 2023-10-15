using CoolWebs.Model.TitleLIst;
using LanguageExt.Common;

namespace CoolWeebs.API.Interfaces
{
    public interface IBaseService<TResponse, TRequest, T> where TResponse : class where TRequest : class
    {
        Task<Result<TResponse>> CreateAsync(TRequest request, CancellationToken cancellationToken);
        Task<Result<TResponse>> GetByIdAsync(T id, CancellationToken cancellationToken);
        Task<Result<TResponse>> UpdateAsync(T id, TRequest request, CancellationToken cancellationToken);
        Task<Result<bool>> DeleteAsync(T id, CancellationToken cancellationToken);
    }
}
