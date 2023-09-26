using CoolWeebs.API.Database;
using CoolWeebs.API.Modules.TitleList.Entities;
using System.Linq.Expressions;

namespace CoolWeebs.API.Modules.TitleList.Repositories
{
    public class TitleRepository: ITitleRepository
    {
        private readonly IBaseRepository<TitleEntity, long> _baseRepository;

        public TitleRepository(IBaseRepository<TitleEntity, long> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<TitleEntity> CreateTitle(TitleEntity transientEntity, CancellationToken cancellationToken)
        {
            return await _baseRepository.Create(transientEntity, cancellationToken);
        }

        public async Task<IEnumerable<TitleEntity>> GetAllTitlesBy(Expression<Func<TitleEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _baseRepository.GetAllBy(predicate, cancellationToken);
        }

        public async Task<TitleEntity?> GetTitleBy(Expression<Func<TitleEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _baseRepository.GetBy(predicate, cancellationToken);
        }

        public async Task<TitleEntity> UpdateTitle(TitleEntity entity, CancellationToken cancellationToken)
        {
            return await _baseRepository.Update(entity, cancellationToken);
        }

        public async Task<TitleEntity> DeleteTitle(TitleEntity entity, CancellationToken cancellationToken)
        {
            return await _baseRepository.Delete(entity, cancellationToken);
        }
    }
}
