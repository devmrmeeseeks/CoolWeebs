using System.Text.Json.Serialization;

namespace CoolWeebs.API.Modules.TitleList.Models
{
    public record ExternalTitleResponse(TitleExternalData[] Data, TitleExternalPagination Pagination);

    public record TitleExternalData(string Title);

    public record TitleExternalPagination 
    {
        [JsonPropertyName("last_visible_page")]
        public int LastVisiblePage { get; init; }

        [JsonPropertyName("current_page")]
        public int CurrentPage { get; init; }

        [JsonPropertyName("has_next_page")]
        public bool HasNextPage { get; init; }
    }
}
