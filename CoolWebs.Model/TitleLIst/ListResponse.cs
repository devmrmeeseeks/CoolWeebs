namespace CoolWebs.Model.TitleLIst
{
    public record ListResponse(
        long Id,

        string Name,

        string? UrlThumbnail,

        string? Description,

        DateTime CreatedAt,

        DateTime UpdatedAt
    );
}
