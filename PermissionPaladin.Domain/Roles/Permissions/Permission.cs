namespace PermissionPaladin.Domain.Roles.Permissions;

public class Permission
{
    /// <summary>
    /// Unique Identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Permission Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Roles with given permission
    /// </summary>
    public List<Role> Roles { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Permission"/> class
    /// </summary>
    /// <param name="name">Name of the permission</param>
    public Permission(string name)
    {
        Name = name;
        Roles = new List<Role>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Permission"/> class
    /// </summary>
    /// <param name="id">The identifier of permission</param>
    /// <param name="name">Name of the permission</param>
    public Permission(int id, string name)
    {
        Id = id;
        Name = name;
        Roles = new List<Role>();
    }

}
