using CoolWeebs.API.Modules.List.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoolWeebs.API.Database
{
    public class BaseContext : DbContext
    {
        public DbSet<TitleListEntity> TitleLists => Set<TitleListEntity>(); 
        public DbSet<ItemEntity> Items => Set<ItemEntity>();

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }
    }
}
