﻿using CoolWeebs.API.Database.Entity;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoolWeebs.API.Database.Repository
{
    public class BaseRepository<E, T> : IBaseRepository<E, T> where E : class, IEntity<T>
    {
        private readonly BaseContext _context;

        public BaseRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task<E> CreateAsync(E transientEntity, CancellationToken cancellationToken = default)
        {
            await _context.Set<E>().AddAsync(transientEntity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return transientEntity;
        }

        public async Task CreateBulk(IEnumerable<E> transientEntities, Expression<Func<E, object>> columnExpression,
            CancellationToken cancellationToken = default)
        {
            await _context.Set<E>().BulkInsertAsync(transientEntities, options => {
                options.InsertIfNotExists = true;
                options.ColumnPrimaryKeyExpression = columnExpression;
            } ,cancellationToken);
        }

        public async Task<IEnumerable<E>> GetAllByAsync(Expression<Func<E, bool>> predicate, CancellationToken cancellationToken = default)
            => await _context.Set<E>().Where(predicate).ToListAsync(cancellationToken);

        public async Task<IEnumerable<E>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _context.Set<E>().ToListAsync(cancellationToken);

        public async Task<E?> GetByAsync(Expression<Func<E, bool>> predicate, CancellationToken cancellationToken = default)
            => await _context.Set<E>().SingleOrDefaultAsync(predicate, cancellationToken);

        public async Task<E?> GetByIdAsync(T id, CancellationToken cancellationToken)
            => await _context.Set<E>().SingleOrDefaultAsync(entity => entity.Id!.Equals(id), cancellationToken);

        public async Task<E> UpdateAsync(E entity, CancellationToken cancellationToken = default)
        {
            _context.Set<E>().Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<E> DeleteAsync(E entity, CancellationToken cancellationToken = default)
        {
            _context.Set<E>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<E?> DeleteByIdAsync(T id, CancellationToken cancellationToken = default)
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
