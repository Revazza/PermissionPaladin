using Microsoft.AspNetCore.Identity;
using PermissionPaladin.Domain.Roles.Permissions;
using PermissionPaladin.Domain.Users;

namespace PermissionPaladin.Domain.Roles;

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

    public void AddPermission(Enums.Permissions permission)
        => Permissions.Add(new Permission(nameof(permission)));

}
