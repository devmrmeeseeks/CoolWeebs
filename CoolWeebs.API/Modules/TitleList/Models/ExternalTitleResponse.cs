namespace CoolWeebs.API.Modules.TitleList.Models
{
    public record ExternalTitleResponse(TitleExternalData[] Data);

    public record TitleExternalData(string Title);
}
