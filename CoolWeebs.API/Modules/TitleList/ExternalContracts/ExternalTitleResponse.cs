using System.Text.Json;
using System.Text.Json.Serialization;

namespace CoolWeebs.API.Modules.TitleList.ExternalContracts
{
    public record ExternalTitleResponse(TitleExternalData[] Data, TitleExternalPagination Pagination);

    public record TitleExternalData {

        [JsonPropertyName("title")]
        public string Title { get; init; } = null!;

        [JsonPropertyName("synopsis")]
        public string? Synopsis { get; init; }

        [JsonPropertyName("episodes")]
        public short? Episodes { get; init; }

        [JsonPropertyName("year")]
        public short? Year { get; init; }
    }

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
