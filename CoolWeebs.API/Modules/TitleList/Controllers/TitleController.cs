using CoolWebs.Model.TitleLIst;
using CoolWeebs.API.Modules.TitleList.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoolWeebs.API.Modules.TitleList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TitleController
    {
        private readonly ITitleService _titleService;
        
        public TitleController(IServiceProvider provider)
        {
            _titleService = provider.GetRequiredService<ITitleService>();
        }

        [HttpPost]
        public async Task<TitleResponse> Post(TitleRequest request, CancellationToken cancellationToken)
        {
            return await _titleService.CreateAsync(request, cancellationToken);
        }
    }
}
