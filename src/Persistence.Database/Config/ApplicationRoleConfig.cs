using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Identity;

namespace Persistence.Database.Config;

public class ApplicationRoleConfig
{
    public ApplicationRoleConfig(EntityTypeBuilder<ApplicationRole> entidad)
    {
        entidad.HasMany(e => e.UserRoles)
               .WithOne(e => e.Role)
               .HasForeignKey(e => e.RoleId)
               .IsRequired();
    }
}
