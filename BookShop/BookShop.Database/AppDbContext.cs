using Microsoft.EntityFrameworkCore;
using BookShop.Domain.Models;

namespace BookShop.Database
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
            {   }

        public DbSet<Product> Products { get; set; }
    }
}
