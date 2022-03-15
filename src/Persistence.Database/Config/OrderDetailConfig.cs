using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Persistence.Database.Config;

public class OrderDetailConfig
{
    public OrderDetailConfig(EntityTypeBuilder<OrderDetail> entidad)
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

        entidad.HasOne(od => od.Order)
        .WithMany(od => od.Items)
        .HasForeignKey(od => od.OrderID);

        entidad.HasOne(od => od.Product)
        .WithMany(od => od.Items)
        .HasForeignKey(od => od.ProductID);
    }
}
