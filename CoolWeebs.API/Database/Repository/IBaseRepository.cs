using System.Linq.Expressions;
using CoolWeebs.API.Database.Entity;

namespace CoolWeebs.API.Database.Repository
{
    public interface IBaseRepository<E, T> where E : IEntity<T>
    {
        Task<E> CreateAsync(E transientEntity, CancellationToken cancellationToken = default);
        Task CreateBulk(IEnumerable<E> transientEntities, Expression<Func<E, object>> columnExpression,
            CancellationToken cancellationToken = default);
        Task<IEnumerable<E>> GetAllByAsync(Expression<Func<E, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<E>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<E?> GetByAsync(Expression<Func<E, bool>> predicate, CancellationToken cancellationToken = default);
        Task<E?> GetByIdAsync(T id, CancellationToken cancellationToken = default);
        Task<E> UpdateAsync(E entity, CancellationToken cancellationToken = default);
        Task<E> DeleteAsync(E entity, CancellationToken cancellationToken = default);
        Task<E?> DeleteByIdAsync(T id, CancellationToken cancellationToken = default);
    }
}
