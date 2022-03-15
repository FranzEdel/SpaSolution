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

        entidad.Property(o => o.Iva)
        .IsRequired()
        .HasColumnType("decimal(10,2)");

        entidad.Property(o => o.SubTotal)
        .IsRequired()
        .HasColumnType("decimal(10,2)");

        entidad.Property(o => o.Total)
        .IsRequired()
        .HasColumnType("decimal(10,2)");

        entidad.HasOne(o => o.Client)
        .WithMany(o => o.Items)
        .HasForeignKey(o => o.ClientID);

    }
}
