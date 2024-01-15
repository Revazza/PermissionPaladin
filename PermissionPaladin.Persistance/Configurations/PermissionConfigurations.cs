using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionPaladin.Domain.Enums;
using PermissionPaladin.Domain.Roles.Permissions;

namespace PermissionPaladin.Persistance.Configurations;

public class PermissionConfigurations : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasData(SeedPermissions());
    }

    private static List<Permission> SeedPermissions()
    {
        return Enum.GetValues<Permissions>()
            .Select(p => new Permission((int)p, p.ToString())).ToList();
    }


}
