using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Wild.Piccolo.Data
{
    public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            // Path is relative to the Data project during design-time
            optionsBuilder.UseSqlite("Data Source=../Registrar.sqlite");
            return new StoreContext(optionsBuilder.Options);
        }
    }
}
