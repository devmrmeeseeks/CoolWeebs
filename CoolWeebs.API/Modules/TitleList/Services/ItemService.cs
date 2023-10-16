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
                return new Result<ItemResponse>(listResult.GetException());
            }

            var titleResult = await _titleService.GetByIdAsync(request.TitleId, cancellationToken);
            if (titleResult.IsFaulted)
            {
                return new Result<ItemResponse>(titleResult.GetException());
            }

            ItemEntity? entity = await _itemRepository.GetByAsync(
                s => (s.ListId.Equals(request.ListId) && s.TitleId.Equals(request.TitleId)) && !s.IsDeleted, cancellationToken);

            if (entity is not null)
            {
                return new Result<ItemResponse>(new ConflictException("Item already exists"));
            }

            entity = _mapper.Map<ItemEntity>(request);
            await _itemRepository.CreateAsync(entity, cancellationToken);
            
            return _mapper.Map<ItemResponse>(entity);
        }


        public async Task<Result<IEnumerable<ItemResponse>>> GetAllByListAsync(long listId, CancellationToken cancellationToken)
        {
            Result<ListResponse> listResult = await _listService.GetByIdAsync(listId, cancellationToken);
            if (listResult.IsFaulted)
            {
                return new Result<IEnumerable<ItemResponse>>(listResult.GetException());
            }

            IEnumerable<ItemEntity> entities = await _itemRepository.GetAllByListAsync(listId, cancellationToken);

            return new Result<IEnumerable<ItemResponse>>(_mapper.Map<IEnumerable<ItemResponse>>(entities));
        }

        public async Task<Result<bool>> DeleteByAsync(long[] items, CancellationToken cancellationToken)
        {
            foreach (long item in items)
            {
                ItemEntity? entity = await _itemRepository.GetByIdAsync(item, cancellationToken);
                if (entity is null)
                {
                    continue;
                }

                entity.IsDeleted = true;
                _ = await _itemRepository.UpdateAsync(entity, cancellationToken);
            }

            return true;
        }
    }
}
