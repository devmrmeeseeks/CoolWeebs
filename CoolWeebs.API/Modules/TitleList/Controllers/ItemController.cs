using CoolWebs.Model.TitleLIst;
using CoolWeebs.API.Extensions;
using CoolWeebs.API.Filters;
using CoolWeebs.API.Modules.TitleList.Services;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;

namespace CoolWeebs.API.Modules.TitleList.Controllers
{
    [ApiController]
    [TrimStringProperties]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IServiceProvider provider)
        {
            _itemService = provider.GetRequiredService<IItemService>();
        }

        [HttpPost]
        public async Task<IActionResult> Post(ItemRequest request, CancellationToken cancellationToken)
        {
            Result<ItemResponse> result = await _itemService.CreateAsync(request, cancellationToken);
            return this.ToResponse(result);
        }
    }
}
