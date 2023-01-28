using Microsoft.EntityFrameworkCore;
using BookShop.Domain.Models;

namespace BookShop.Database
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

    }
}
