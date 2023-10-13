using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolWebs.Model.TitleLIst
{
    public record TitleRequest
    (
        string Title,
        string? Description
    );
}
