using Microsoft.AspNetCore.Identity;

namespace Model.Identity;
public class ApplicationRole : IdentityRole
{
    public List<ApplicationUserRole>? UserRoles { get; set; }
}
