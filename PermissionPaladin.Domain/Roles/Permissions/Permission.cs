namespace PermissionPaladin.Domain.Roles.Permissions;

public class Permission
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Role> Roles { get; set; }

    public Permission()
    {
        Name = string.Empty;
        Roles = new List<Role>();
    }

}
