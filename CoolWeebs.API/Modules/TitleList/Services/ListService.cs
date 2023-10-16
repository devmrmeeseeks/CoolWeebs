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
    public class ListService : IListService
    {
        private readonly IListRepository _listRepository;
        private readonly IValidator<ListRequest> _validator;
        private readonly IMapper _mapper;

        public ListService(IServiceProvider provider)
        {
            _listRepository = provider.GetRequiredService<IListRepository>();
            _validator = provider.GetRequiredService<IValidator<ListRequest>>();
            _mapper = provider.GetRequiredService<IMapper>();
        }

        public async Task<Result<ListResponse>> CreateAsync(ListRequest request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new Result<ListResponse>(new ValidationException(validationResult.Errors));
            }

            ListEntity? entity = await _listRepository.GetByAsync(
                s => s.Name.Equals(request.Name) && !s.IsDeleted, cancellationToken);

            if (entity is not null)
            {
                return new Result<ListResponse>(new ConflictException("List already exists"));
            }

            entity = _mapper.Map<ListEntity>(request);
            await _listRepository.CreateAsync(entity, cancellationToken);

            return _mapper.Map<ListResponse>(entity);
        }

        public async Task<Result<bool>> DeleteAsync(long id, CancellationToken cancellationToken)
        {
            ListEntity? entity = await _listRepository.GetByAsync(
                s => s.Id.Equals(id) && !s.IsDeleted, cancellationToken);

            if (entity is null)
            {
                return new Result<bool>(new NotFoundException("List not found"));
            }

            entity.IsDeleted = true;
            await _listRepository.UpdateAsync(entity, cancellationToken);

            return true;
        }

        public async Task<Result<ListResponse>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            ListEntity? entity = await _listRepository.GetByAsync(
                s =>s.Id.Equals(id) && !s.IsDeleted, cancellationToken);

            if (entity is null)
            {
                return new Result<ListResponse>(new NotFoundException("List not found"));
            }

            return _mapper.Map<ListResponse>(entity);
        }

        public async Task<Result<IEnumerable<ListResponse>>> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            IEnumerable<ListEntity> entities = await _listRepository.GetAllByAsync(
                s => s.Name.ToLower().Contains(name) && !s.IsDeleted, cancellationToken);

            IEnumerable<ListResponse> result = _mapper.Map<IEnumerable<ListResponse>>(entities);

            return new Result<IEnumerable<ListResponse>>(result);
        }

        public async Task<Result<ListResponse>> UpdateAsync(long id, ListRequest request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new Result<ListResponse>(new ValidationException(validationResult.Errors));
            }

            ListEntity? entity = await _listRepository.GetByAsync(
                s => s.Id.Equals(id) && !s.IsDeleted, cancellationToken);

            if (entity is null)
            {
                return new Result<ListResponse>(new NotFoundException("List not found"));
            }

            entity = _mapper.Map(request, entity);
            await _listRepository.UpdateAsync(entity, cancellationToken);

            return _mapper.Map<ListResponse>(entity);
        }
    }
}
