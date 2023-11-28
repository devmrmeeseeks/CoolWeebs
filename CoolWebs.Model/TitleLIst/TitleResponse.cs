namespace CoolWebs.Model.TitleLIst
{
    public record TitleResponse
    (
        long Id,

        string Name,

        string? UrlThumbnail,

        string? Synopsis,

        short? Episodes,

        short? Year,

        DateTime CreatedAt,

        DateTime UpdatedAt
    );
}
