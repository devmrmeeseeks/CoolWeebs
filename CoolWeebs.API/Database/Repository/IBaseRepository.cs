using System.Linq.Expressions;
using CoolWeebs.API.Entity;

namespace CoolWeebs.API.Database.Repository
{
    public interface IBaseRepository<E, T> where E : IEntity<T>
    {
        Task<E> CreateAsync(E transientEntity, CancellationToken cancellationToken);
        Task<IEnumerable<E>> GetAllByAsync(Expression<Func<E, bool>> predicate, CancellationToken cancellationToken);
        Task<IEnumerable<E>> GetAllAsync(CancellationToken cancellationToken);
        Task<E?> GetByAsync(Expression<Func<E, bool>> predicate, CancellationToken cancellationToken);
        Task<E?> GetByIdAsync(T id, CancellationToken cancellationToken);
        Task<E> UpdateAsync(E entity, CancellationToken cancellationToken);
        Task<E> DeleteAsync(E entity, CancellationToken cancellationToken);
        Task<E?> DeleteByIdAsync(T id, CancellationToken cancellationToken);
    }
}
