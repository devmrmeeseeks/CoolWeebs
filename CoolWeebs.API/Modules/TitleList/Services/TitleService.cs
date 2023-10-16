using AutoMapper;
using CoolWebs.Model.TitleLIst;
using CoolWeebs.API.Exceptions;
using CoolWeebs.API.Modules.TitleList.Entities;
using CoolWeebs.API.Modules.TitleList.Repositories;
using FluentValidation;
using FluentValidation.Results;
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
            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new Result<TitleResponse>(new ValidationException(validationResult.Errors));
            }

            TitleEntity? entity = await _titleRepository.GetByAsync(
                s => s.Name.Equals(request.Name) && !s.IsDeleted, cancellationToken);

            if (entity is not null)
            {
                return new Result<TitleResponse>(new ConflictException("Title already exists"));
            }

            entity = _mapper.Map<TitleEntity>(request);
            await _titleRepository.CreateAsync(entity, cancellationToken);

            return _mapper.Map<TitleResponse>(entity);
        }

        public async Task<Result<TitleResponse>> UpdateAsync(long id,TitleRequest request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new Result<TitleResponse>(new ValidationException(validationResult.Errors));
            }

            TitleEntity? entity = await _titleRepository.GetByAsync(
                s => s.Id.Equals(id) && !s.IsDeleted, cancellationToken);

            if (entity is null)
            {
                return new Result<TitleResponse>(new NotFoundException("Title not found"));
            }

            entity = _mapper.Map(request, entity);
            await _titleRepository.UpdateAsync(entity, cancellationToken);

            return _mapper.Map<TitleResponse>(entity);
        }

        public async Task<Result<TitleResponse>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            TitleEntity? entity = await _titleRepository.GetByAsync(
                s => s.Id.Equals(id) && !s.IsDeleted, cancellationToken);

            if (entity is null)
            {
                return new Result<TitleResponse>(new NotFoundException("Title not found"));
            }

            return _mapper.Map<TitleResponse>(entity);
        }

        public async Task<Result<IEnumerable<TitleResponse>>> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            IEnumerable<TitleEntity> entities = await _titleRepository.GetAllByAsync(
                s => s.Name.ToLower().Contains(name) && !s.IsDeleted, cancellationToken);

            IEnumerable<TitleResponse> result = _mapper.Map<IEnumerable<TitleResponse>>(entities);

            return new Result<IEnumerable<TitleResponse>>(result);
        }

        public async Task<Result<bool>> DeleteAsync(long id, CancellationToken cancellationToken)
        {
            TitleEntity? entity = await _titleRepository.GetByAsync(
                    s => s.Id.Equals(id) && !s.IsDeleted, cancellationToken);

            if (entity is null)
            {
                return new Result<bool>(new NotFoundException("Title not found"));
            }

            entity.IsDeleted = true;
            await _titleRepository.UpdateAsync(entity, cancellationToken);

            return true;
        }
    }
}
