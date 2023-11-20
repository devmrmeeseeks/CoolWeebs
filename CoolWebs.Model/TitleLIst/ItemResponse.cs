namespace CoolWebs.Model.TitleLIst
{
    public record ItemResponse(long Id, bool IsCompleted, TitleResponse Title,
        DateTime CreatedAt, DateTime UpdatedAt)
    {
        public ItemResponse(long id, bool isCompleted, DateTime createdAt, DateTime updatedAt)
            : this(id, isCompleted, null!, createdAt, updatedAt)
        {
        }
    }
}
