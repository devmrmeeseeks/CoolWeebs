namespace CoolWeebs.API.Common.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
