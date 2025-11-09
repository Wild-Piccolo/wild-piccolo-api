using Wild.Piccolo.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Wild.Piccolo.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ModelBuilder builder)
        {
            builder.Entity<Item>().HasData(
                new Item("Shirt", "Ohio State shirt", "Nike", 29.99m)
                {
                    Id = 1
                },
                new Item("Shorts", "Ohio State shorts", "Nike", 44.9m)
                {
                    Id = 2
                }
            );
        }
    }
}
