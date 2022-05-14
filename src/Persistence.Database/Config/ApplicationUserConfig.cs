using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Identity;

namespace Persistence.Database.Config;

public class ApplicationUserConfig
{
    public ApplicationUserConfig(EntityTypeBuilder<ApplicationUser> entidad)
    {
        entidad.HasMany(e => e.UserRoles)
               .WithOne(e => e.User)
               .HasForeignKey(e => e.UserId)
               .IsRequired();
    }
}
