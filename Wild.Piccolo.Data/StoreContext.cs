using Wild.Piccolo.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Wild.Piccolo.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        { }

        public DbSet<Item> Items { get; set; }
    }

    public class Class1
    {
        // Keep this empty class because instructions say not to remove it
    }
}
