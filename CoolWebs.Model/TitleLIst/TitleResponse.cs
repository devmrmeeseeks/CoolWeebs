﻿namespace CoolWebs.Model.TitleLIst
{
    public record TitleResponse
    (
        long Id,

        string Name,

        string? UrlThumbnail,

        string? Description,

        DateTime CreatedAt,

        DateTime UpdatedAt
    );
}
