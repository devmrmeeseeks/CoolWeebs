using System.Linq.Expressions;

namespace CoolWeebs.API.Database
{
    public interface IBaseRepository<E, T> where E : class
    {
        Task<E> Create(E transientEntity, CancellationToken cancellationToken);
        Task<IEnumerable<E>> GetAllBy(Expression<Func<E, bool>> predicate, CancellationToken cancellationToken);
        Task<IEnumerable<E>> GetAll(CancellationToken cancellationToken);
        Task<E?> GetBy(Expression<Func<E, bool>> predicate, CancellationToken cancellationToken);
        Task<E?> GetById(T id, CancellationToken cancellationToken);
        Task<E> Update(E entity, CancellationToken cancellationToken);
        Task<E> Delete(E entity, CancellationToken cancellationToken);
        Task<E?> DeleteById(T id, CancellationToken cancellationToken);
    }
}
