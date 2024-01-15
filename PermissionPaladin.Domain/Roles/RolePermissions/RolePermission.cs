namespace PermissionPaladin.Domain.Roles.RolePermissions;

/// <summary>
/// Represents the association between a role and a permission in the database
/// This class is designed to be used as a table to store role-permission relationships
/// </summary>
public class RolePermission
{
    /// <summary>
    /// Gets or sets the identifier of the role (foreign key)
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the permission (foreign key)
    /// </summary>
    public int PermissionId { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RolePermission"/> class
    /// </summary>
    /// <param name="roleId">The identifier of the role (foreign key)</param>
    /// <param name="permissionId">The identifier of the permission (foreign key)</param>
    public RolePermission(int roleId, int permissionId)
    {
        RoleId = roleId;
        PermissionId = permissionId;
    }
}
