namespace PermissionPaladin.Domain.Roles;

public static class RolesProvider
{
    public static Role Admin { get; set; } = new Role(1, "Admin");
    public static Role Manager { get; set; } = new Role(2, "Manager");
    public static Role Customer { get; set; } = new Role(3, "Customer");

}
