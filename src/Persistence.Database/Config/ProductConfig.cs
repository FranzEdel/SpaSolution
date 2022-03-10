using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Persistence.Database.Config;

public class ProductConfig
{
    public ProductConfig(EntityTypeBuilder<Product> entidad)
    {
        entidad.ToTable("Products");

        entidad.HasKey(p => p.ProductID);

        entidad.Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

        entidad.Property(p => p.Description)
        .IsRequired()
        .HasMaxLength(250)
        .IsUnicode(false);

        entidad.Property(p => p.Price)
        .IsRequired()
        .HasColumnType("decimal(10,2)");
    }
}
