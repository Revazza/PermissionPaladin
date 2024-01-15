namespace PermissionPaladin.Domain.Roles;

public static class RolesProvider
{
    public static Role Admin { get; set; } = SetupAdmin();
    public static Role Manager { get; set; } = new Role(2, "Manager");
    public static Role Customer { get; set; } = new Role(3, "Customer");


    private static Role SetupAdmin()
    {
        return new(1, "Admin");
    }

}
