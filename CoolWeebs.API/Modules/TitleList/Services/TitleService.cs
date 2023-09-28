using AutoMapper;
using CoolWebs.Model.TitleLIst;
using CoolWeebs.API.Modules.TitleList.Entities;
using CoolWeebs.API.Modules.TitleList.Repositories;

namespace CoolWeebs.API.Modules.TitleList.Services
{
    public class TitleService : ITitleService
    {
        private readonly ITitleRepository _titleRepository;
        private readonly IMapper _mapper;

        public TitleService(IServiceProvider provider)
        {
            _titleRepository = provider.GetRequiredService<ITitleRepository>();
            _mapper = provider.GetRequiredService<IMapper>();
        }

        public async Task<TitleResponse> CreateAsync(TitleRequest request, CancellationToken cancellationToken)
        {
            TitleEntity? entity = await _titleRepository.GetByAsync(s => s.Title.Equals(request.Title), cancellationToken);
            if (entity is not null)
            {
                throw new Exception("Title already exists");
            }

            entity = _mapper.Map<TitleEntity>(request);
            await _titleRepository.CreateAsync(entity, cancellationToken);

            return _mapper.Map<TitleResponse>(entity);
        }
    }
}
