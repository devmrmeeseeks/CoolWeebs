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
    public class ListController : ControllerBase
    {
        private readonly IListService _listService;

        public ListController(IServiceProvider provider)
        {
            _listService = provider.GetRequiredService<IListService>();
        }

        [HttpPost]
        public async Task<IActionResult> Post(ListRequest request, CancellationToken cancellationToken)
        {
            Result<ListResponse> result = await _listService.CreateAsync(request, cancellationToken);
            return this.ToResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            Result<ListResponse> result = await _listService.GetByIdAsync(id, cancellationToken);
            return this.ToResponse(result);
        }

        [HttpGet("search/{name}")]
        public async Task<IActionResult> Get(string name, CancellationToken cancellationToken)
        {
            Result<IEnumerable<ListResponse>> result = await _listService.GetByNameAsync(name, cancellationToken);
            return this.ToResponse(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(long id, ListRequest request, CancellationToken cancellationToken)
        {
            Result<ListResponse> result = await _listService.UpdateAsync(id, request, cancellationToken);
            return this.ToResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            Result<bool> result = await _listService.DeleteAsync(id, cancellationToken);
            return this.ToResponse(result);
        }
    }
}
