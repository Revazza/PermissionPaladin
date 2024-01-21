using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionPaladin.Domain.Enums;
using PermissionPaladin.Domain.Roles;
using PermissionPaladin.Domain.Roles.RolePermissions;

namespace PermissionPaladin.Persistance.Configurations;

public class RolePermissionConfigurations : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasData(SeedRolePermissions());
    }

    private static List<RolePermission> SeedRolePermissions()
    {
        return new List<RolePermission>()
            .Concat(GetAdminPermissions())
            .Concat(GetManagerPermissions())
            .Concat(GetCustomerPermissions())
            .ToList();
    }

    private static List<RolePermission> GetCustomerPermissions()
    {
        return new List<RolePermission>()
        {
            Create(RolesProvider.Customer,AccessPermissions.ViewProduct),
            Create(RolesProvider.Customer,AccessPermissions.AccessUserMenu),
        };
    }

    private static List<RolePermission> GetManagerPermissions()
    {
        return new List<RolePermission>()
        {
            Create(RolesProvider.Manager,AccessPermissions.AddProduct),
            Create(RolesProvider.Manager,AccessPermissions.AccessUserMenu),
            Create(RolesProvider.Manager,AccessPermissions.UpdateProduct),
        };
    }

    private static List<RolePermission> GetAdminPermissions()
    {
        return Enum.GetValues<AccessPermissions>()
            .Select(p =>
                Create(RolesProvider.Admin, p)
             ).ToList();
    }

    private static RolePermission Create(Role role, AccessPermissions permission)
    {
        return new RolePermission(role.Id, (int)permission);
    }


}
