using Microsoft.EntityFrameworkCore;
using Model;
using Persistence.Database.Config;

namespace Persistence.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
    public DbSet<Client>? Client { get; set; }
    public DbSet<Order>? Order { get; set; }
    public DbSet<OrderDetail>? OrderDetail { get; set; }
    public DbSet<Product>? Product { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new ClientConfig(modelBuilder.Entity<Client>());

        new ProductConfig(modelBuilder.Entity<Product>());

        new OrderConfig(modelBuilder.Entity<Order>());

        new OrderDetailConfig(modelBuilder.Entity<OrderDetail>());
    }
}
