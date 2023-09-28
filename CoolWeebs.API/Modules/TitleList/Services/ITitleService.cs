using CoolWebs.Model.TitleLIst;

namespace CoolWeebs.API.Modules.TitleList.Services
{
    public interface ITitleService
    {
        Task<TitleResponse> CreateAsync(TitleRequest request, CancellationToken cancellationToken);
    }
}
