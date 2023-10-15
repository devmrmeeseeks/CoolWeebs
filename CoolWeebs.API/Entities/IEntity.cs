namespace CoolWeebs.API.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
