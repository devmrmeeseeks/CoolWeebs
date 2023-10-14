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
    public class TitleController : ControllerBase
    {
        private readonly ITitleService _titleService;

        public TitleController(IServiceProvider provider)
        {
            _titleService = provider.GetRequiredService<ITitleService>();
        }

        [HttpPost]
        public async Task<IActionResult> Post(TitleRequest request, CancellationToken cancellationToken)
        {
            Result<TitleResponse> result = await _titleService.CreateAsync(request, cancellationToken);
            return this.ToResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            Result<TitleResponse> result = await _titleService.GetByIdAsync(id, cancellationToken);
            return this.ToResponse(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(long id, TitleRequest request, CancellationToken cancellationToken)
        {
            Result<TitleResponse> result = await _titleService.UpdateAsync(id, request, cancellationToken);
            return this.ToResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            Result<bool> result = await _titleService.DeleteAsync(id, cancellationToken);
            return this.ToResponse(result);
        }
    }
}
