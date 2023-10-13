using AutoMapper;
using CoolWebs.Model.TitleLIst;
using CoolWeebs.API.Common.Exceptions;
using CoolWeebs.API.Modules.TitleList.Entities;
using CoolWeebs.API.Modules.TitleList.Repositories;
using FluentValidation;
using LanguageExt.Common;

namespace CoolWeebs.API.Modules.TitleList.Services
{
    public class TitleService : ITitleService
    {
        private readonly ITitleRepository _titleRepository;
        private readonly IValidator<TitleRequest> _validator;
        private readonly IMapper _mapper;

        public TitleService(IServiceProvider provider)
        {
            _titleRepository = provider.GetRequiredService<ITitleRepository>();
            _validator = provider.GetRequiredService<IValidator<TitleRequest>>();
            _mapper = provider.GetRequiredService<IMapper>();
        }

        public async Task<Result<TitleResponse>> CreateAsync(TitleRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new Result<TitleResponse>(new ValidationException(validationResult.Errors));
            }

            TitleEntity? entity = await _titleRepository.GetByAsync(s => s.Title.Equals(request.Title), cancellationToken);
            if (entity is not null)
            {
                return new Result<TitleResponse>(new ConflictException("Title already exists"));
            }

            entity = _mapper.Map<TitleEntity>(request);

            await _titleRepository.CreateAsync(entity, cancellationToken);

            return _mapper.Map<TitleResponse>(entity);
        }

        public async Task<Result<TitleResponse>> UpdateAsync(long id, TitleRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new Result<TitleResponse>(new ValidationException(validationResult.Errors));
            }

            TitleEntity? entity = await _titleRepository.GetByIdAsync(id, cancellationToken);
            if (entity is null)
            {
                return new Result<TitleResponse>(new ConflictException("Title not found"));
            }

            entity = _mapper.Map(request, entity);
            entity.UpdatedAt = DateTime.UtcNow;

            await _titleRepository.UpdateAsync(entity, cancellationToken);

            return _mapper.Map<TitleResponse>(entity);
        }

        public async Task<Result<TitleResponse>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            TitleEntity? entity = await _titleRepository.GetByIdAsync(id, cancellationToken);
            if (entity is null)
            {
                return new Result<TitleResponse>(new ConflictException("Title not found"));
            }

            return _mapper.Map<TitleResponse>(entity);
        }
    }
}
