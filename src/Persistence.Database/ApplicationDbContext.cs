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

        modelBuilder.Entity<Order>(entidad =>
        {
            entidad.ToTable("Orders");

            entidad.HasKey(o => o.OrderID);

            entidad.Property(od => od.Iva)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

            entidad.Property(od => od.SubTotal)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

            entidad.Property(od => od.Total)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        });

        modelBuilder.Entity<Order>().HasOne(x => x.Client)
        .WithMany(p => p.Items)
        .HasForeignKey(p => p.ClientID);


        modelBuilder.Entity<OrderDetail>(entidad =>
        {
            entidad.ToTable("OrderDetail");

            entidad.HasKey(od => od.OrderDetailID);

            entidad.Property(od => od.UnitPrice)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

            entidad.Property(od => od.Iva)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

            entidad.Property(od => od.SubTotal)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

            entidad.Property(od => od.Total)
            .IsRequired()
            .HasColumnType("decimal(10,2)");
        });


        modelBuilder.Entity<OrderDetail>().HasOne(x => x.Order)
        .WithMany(p => p.Items)
        .HasForeignKey(p => p.OrderID);

        modelBuilder.Entity<OrderDetail>().HasOne(x => x.Product)
        .WithMany(p => p.Items)
        .HasForeignKey(p => p.ProductID);
    }
}
