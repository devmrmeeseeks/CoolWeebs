using CoolWebs.Model.TitleLIst;
using CoolWeebs.API.Common.Extensions;
using CoolWeebs.API.Modules.TitleList.Services;
using FluentValidation;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoolWeebs.API.Modules.TitleList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TitleController : ControllerBase
    {
        private readonly ITitleService _titleService;

        public TitleController(IServiceProvider provider)
        {
            _titleService = provider.GetRequiredService<ITitleService>();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(TitleRequest request, CancellationToken cancellationToken)
        {
            Result<TitleResponse> result = await _titleService.CreateAsync(request, cancellationToken);
            return this.ToResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id, CancellationToken cancellationToken)
        {
            Result<TitleResponse> result = await _titleService.GetByIdAsync(id, cancellationToken);
            return this.ToResponse(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAsync(long id, TitleRequest request, CancellationToken cancellationToken)
        {
            Result<TitleResponse> result = await _titleService.UpdateAsync(id, request, cancellationToken);
            return this.ToResponse(result);
        }
    }
}
