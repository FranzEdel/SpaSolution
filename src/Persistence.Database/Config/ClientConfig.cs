using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Persistence.Database.Config;
public class ClientConfig
{
    public ClientConfig(EntityTypeBuilder<Client> entidad)
    {
        entidad.ToTable("Clients");

        entidad.HasKey(c => c.ClientID);

        entidad.Property(c => c.Name)
        .IsRequired()
        .HasMaxLength(25)
        .IsUnicode(false);
    }
}
