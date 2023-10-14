using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolWebs.Model.TitleLIst
{
    public record TitleResponse
    (
        string Name,

        string? UrlThumbnail,

        string? Description,

        DateTime CreatedAt,

        DateTime? UpdatedAt
    );
}
