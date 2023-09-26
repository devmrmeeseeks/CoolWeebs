using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoolWeebs.API.Database
{
    public class BaseRepository<E, T> : IBaseRepository<E, T> where E : class
    {
        private readonly BaseContext _context;

        public BaseRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task<E> Create(E transientEntity, CancellationToken cancellationToken)
        {
            await _context.Set<E>().AddAsync(transientEntity);
            await _context.SaveChangesAsync(cancellationToken);
            return transientEntity;
        }

        public async Task<IEnumerable<E>> GetAllBy(Expression<Func<E, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _context.Set<E>().Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<E>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Set<E>().ToListAsync(cancellationToken);
        }

        public async Task<E?> GetBy(Expression<Func<E, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _context.Set<E>().SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<E?> GetById(T id, CancellationToken cancellationToken)
        {
            return await _context.Set<E>().SingleOrDefaultAsync(id => id.Equals(id), cancellationToken);
        }

        public async Task<E> Update(E entity, CancellationToken cancellationToken)
        {
            _context.Set<E>().Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<E> Delete(E entity, CancellationToken cancellationToken)
        {
            _context.Set<E>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<E?> DeleteById(T id, CancellationToken cancellationToken)
        {
            var entity = await _context.Set<E>().FindAsync(id, cancellationToken);
            if (entity is null)
            {
                return null;
            }

            _context.Set<E>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
