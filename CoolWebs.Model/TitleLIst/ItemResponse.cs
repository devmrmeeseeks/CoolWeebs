namespace CoolWebs.Model.TitleLIst
{
    public record ItemResponse
    (
        long Id,

        bool IsCompleted,

        TitleResponse? Title
    );
}
