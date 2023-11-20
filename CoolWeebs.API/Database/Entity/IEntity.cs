namespace CoolWeebs.API.Database.Entity
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
