using CoolWeebs.API.Modules.TitleList.Entities;
using System.Linq.Expressions;

namespace CoolWeebs.API.Modules.TitleList.Repositories
{
    public interface ITitleRepository
    {
        Task<TitleEntity> CreateTitle(TitleEntity transientEntity, CancellationToken cancellationToken);
        Task<IEnumerable<TitleEntity>> GetAllTitlesBy(Expression<Func<TitleEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<TitleEntity?> GetTitleBy(Expression<Func<TitleEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<TitleEntity> UpdateTitle(TitleEntity entity, CancellationToken cancellationToken);
        Task<TitleEntity> DeleteTitle(TitleEntity entity, CancellationToken cancellationToken);
    }
}
