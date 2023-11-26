using AutoMapper;
using CoolWebs.Model.TitleLIst;
using CoolWeebs.API.Exceptions;
using CoolWeebs.API.Modules.TitleList.Entities;
using CoolWeebs.API.Modules.TitleList.Models;
using CoolWeebs.API.Modules.TitleList.Repositories;
using CoolWeebs.API.utilities;
using FluentValidation;
using FluentValidation.Results;
using LanguageExt.Common;

namespace CoolWeebs.API.Modules.TitleList.Services
{
    public class TitleService : ITitleService
    {
        private readonly ITitleRepository _titleRepository;
        private readonly IValidator<TitleRequest> _validator;
        private readonly IHttpClientUtility _httpClientUtility;
        private readonly IMapper _mapper;

        public TitleService(IServiceProvider provider)
        {
            _titleRepository = provider.GetRequiredService<ITitleRepository>();
            _validator = provider.GetRequiredService<IValidator<TitleRequest>>();
            _httpClientUtility = provider.GetRequiredService<IHttpClientUtility>();
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
            IEnumerable<TitleExternalData> response = await GetExternalTitlesAsync(new { q = name, page = 1 }, cancellationToken);

            if (!response.Any()) {
                return new Result<IEnumerable<TitleResponse>>(new NotFoundException("Title not found"));
            }

            IEnumerable<TitleResponse> result;
            HashSet<string> responseHashSet = new HashSet<string>(response.Select(r => r.Title));
            IEnumerable<TitleEntity> entities = await _titleRepository.GetAllByAsync(s => responseHashSet.Any(r => r.Equals(s.Name)), cancellationToken);
            IEnumerable<TitleExternalData> transientTitles = response.Except(entities.Select(e => new TitleExternalData(e.Name)),
                EqualityComparer<TitleExternalData>.Default);

            if (transientTitles.Length() > 0) {
                IEnumerable<TitleEntity> titles = _mapper.Map<IEnumerable<TitleEntity>>(transientTitles);
                await _titleRepository.CreateRangeAsync(titles, cancellationToken);
                result = _mapper.Map<IEnumerable<TitleResponse>>(titles);
            } else {
                result = _mapper.Map<IEnumerable<TitleResponse>>(entities);
            }

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

        #region Private Methods
        private async Task<IEnumerable<TitleExternalData>> GetExternalTitlesAsync(dynamic filter, CancellationToken cancellationToken = default)
        {
            ExternalTitleResponse? response = await _httpClientUtility.GetAsync<ExternalTitleResponse>(filter, cancellationToken);
            if (response is null) return Enumerable.Empty<TitleExternalData>();
            if (!response.Pagination.HasNextPage) return response.Data;
            IEnumerable<TitleExternalData> titles = await GetExternalTitlesAsync(new {
                q = filter.q,
                page = filter.page + 1
            }, cancellationToken);

            return response.Data.Concat(titles);

        }
        #endregion
    }
}
