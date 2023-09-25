using Microsoft.EntityFrameworkCore;

namespace CoolWeebs.API.Database
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }
    }
}
