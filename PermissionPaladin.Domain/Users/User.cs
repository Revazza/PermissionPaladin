using Microsoft.AspNetCore.Identity;
using PermissionPaladin.Domain.Roles;

namespace PermissionPaladin.Domain.Users;

/// <summary>
/// Custom user class extending IdentityUser
/// </summary>
public class User : IdentityUser<int>
{
    public List<Role> Roles { get; set; }

    public User()
    {
        Roles = new List<Role>();
    }

    /// <summary>
    /// Adds a new role to the user's roles list
    /// </summary>
    /// <param name="newRole">The role to be added</param>
    public void AddToRole(Role newRole)
    {
        Roles.Add(newRole);
    }

    /// <summary>
    /// Checks if the user is in the specified role
    /// </summary>
    /// <param name="role">The role to check</param>
    /// <returns>True if the user is in the specified role; otherwise, false</returns>
    public bool IsInRole(Role role)
    {
        return Roles.Contains(role);
    }

    /// <summary>
    /// Checks if the user is in the role with the specified name
    /// </summary>
    /// <param name="roleName">The name of the role to check</param>
    /// <returns>True if the user is in the specified role; otherwise, false</returns>
    public bool IsInRole(string roleName)
    {
        return Roles.Any(role => role.Name == roleName);
    }
}
