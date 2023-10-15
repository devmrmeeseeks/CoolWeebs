using AutoMapper;
using CoolWebs.Model.TitleLIst;
using CoolWeebs.API.Exceptions;
using CoolWeebs.API.Extensions;
using CoolWeebs.API.Modules.TitleList.Entities;
using CoolWeebs.API.Modules.TitleList.Repositories;
using FluentValidation;
using FluentValidation.Results;
using LanguageExt.Common;

namespace CoolWeebs.API.Modules.TitleList.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IListService _listService;
        private readonly ITitleService _titleService;
        private readonly IValidator<ItemRequest> _validator;
        private readonly IMapper _mapper;

        public ItemService(IServiceProvider provider)
        {
            _itemRepository = provider.GetRequiredService<IItemRepository>();
            _listService = provider.GetRequiredService<IListService>();
            _titleService = provider.GetRequiredService<ITitleService>();
            _validator = provider.GetRequiredService<IValidator<ItemRequest>>();
            _mapper = provider.GetRequiredService<IMapper>();
        }

        public async Task<Result<ItemResponse>> CreateAsync(ItemRequest request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new Result<ItemResponse>(new ValidationException(validationResult.Errors));
            }

            var listResult = await _listService.GetByIdAsync(request.ListId, cancellationToken);
            if (listResult.IsFaulted)
            {
                return new Result<ItemResponse>(new NotFoundException("List not found"));
            }

            var titleResult = await _titleService.GetByIdAsync(request.TitleId, cancellationToken);
            if (titleResult.IsFaulted)
            {
                return new Result<ItemResponse>(new NotFoundException("Title not found"));
            }

            ItemEntity? entity = await _itemRepository.GetByAsync(
                s => (s.ListId.Equals(request.ListId) && s.TitleId.Equals(request.TitleId)) && !s.IsDeleted, cancellationToken);

            if (entity is not null)
            {
                return new Result<ItemResponse>(new ConflictException("Item already exists"));
            }

            entity = _mapper.Map<ItemEntity>(request);
            await _itemRepository.CreateAsync(entity, cancellationToken);
            ItemResponse result = _mapper.Map<ItemResponse>(entity);

            return result with { Title = titleResult.GetValue() };
        }

        public Task<Result<bool>> DeleteAsync(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ItemResponse>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ItemResponse>> UpdateAsync(long id, ItemRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
