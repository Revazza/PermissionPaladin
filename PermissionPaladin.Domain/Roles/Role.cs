using Microsoft.AspNetCore.Identity;
using PermissionPaladin.Domain.Enums;
using PermissionPaladin.Domain.Roles.Permissions;
using PermissionPaladin.Domain.Users;

namespace PermissionPaladin.Domain.Roles;

/// <summary>
/// Custom role class extending IdentityRole with additional properties
/// </summary>
public class Role : IdentityRole<int>
{
    public List<User> Users { get; set; }
    public List<Permission> Permissions { get; set; }

    public Role()
    {
        Users = new List<User>();
        Permissions = new List<Permission>();
    }

    public Role(int id, string roleName)
    {
        Id = id;
        Name = roleName;
        NormalizedName = Name.ToUpper();
        ConcurrencyStamp = Guid.NewGuid().ToString();
        Permissions = new List<Permission>();
        Users = new List<User>();
    }

    /// <summary>
    /// Adds a permission to the role.
    /// </summary>
    /// <param name="permission">The access permission to add</param>
    public void AddPermission(AccessPermissions permission)
        => Permissions.Add(new Permission(permission.ToString()));

}
