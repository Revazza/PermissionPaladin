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

    public void AddToRole(Role newRole)
    {
        Roles.Add(newRole);
    }

    public bool IsInRole(Role role)
    {
        return Roles.Contains(role);
    }

    public bool IsInRole(string roleName)
    {
        return Roles.Any(role => role.Name == roleName);
    }
}
