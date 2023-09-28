namespace CoolWeebs.API.Common.Repository
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
