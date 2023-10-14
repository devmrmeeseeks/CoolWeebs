using CoolWeebs.API.Modules.TitleList.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoolWeebs.API.Database
{
    public class BaseContext : DbContext
    {
        public DbSet<ListEntity> Lists { get; set; } = null!;
        public DbSet<ItemEntity> Items { get; set; } = null!;
        public DbSet<TitleEntity> Titles { get; set; } = null!;

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseContext).Assembly);
        }
    }
}
