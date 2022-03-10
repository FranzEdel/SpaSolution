using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Persistence.Database.Config;

public class OrderConfig
{
    public OrderConfig(EntityTypeBuilder<Order> entidad)
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

    }
}
