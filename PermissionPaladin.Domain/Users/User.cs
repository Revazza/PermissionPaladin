using Microsoft.AspNetCore.Identity;
using PermissionPaladin.Domain.Roles;

namespace PermissionPaladin.Domain.Users;

public class User : IdentityUser<int>
{
    public List<Role> Roles { get; set; }

    public User()
    {
        Roles = new List<Role>();
    }
}
