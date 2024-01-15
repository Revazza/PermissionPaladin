using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionPaladin.Domain.Roles;
using PermissionPaladin.Domain.Roles.RolePermissions;

namespace PermissionPaladin.Persistance.Configurations;

public class RoleConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasMany(role => role.Permissions)
            .WithMany(perrmission => perrmission.Roles)
            .UsingEntity<RolePermission>();

        builder.HasData(SeedRoles());
    }

    public static List<Role> SeedRoles()
    {
        return new List<Role>
        {
            RolesProvider.Admin,
            RolesProvider.Manager,
            RolesProvider.Customer,
        };
    }

}
