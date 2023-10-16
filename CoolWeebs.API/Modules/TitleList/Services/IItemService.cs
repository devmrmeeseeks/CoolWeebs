using CoolWebs.Model.TitleLIst;
using LanguageExt.Common;

namespace CoolWeebs.API.Modules.TitleList.Services
{
    public interface IItemService
    {
        Task<Result<ItemResponse>> CreateAsync(ItemRequest request, CancellationToken cancellationToken);
        Task<Result<IEnumerable<ItemResponse>>> GetAllByListAsync(long listId, CancellationToken cancellationToken);
        Task<Result<bool>> DeleteByAsync(long[] items, CancellationToken cancellationToken);
    }
}
