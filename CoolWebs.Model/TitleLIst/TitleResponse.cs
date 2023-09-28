using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolWebs.Model.TitleLIst
{
    public class TitleResponse
    {
        public string Title { get; set; } = null!;

        public string? UrlThumbnail { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
