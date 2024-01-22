using PermissionPaladin.Domain.Products;
using PermissionPaladin.Domain.Roles;

namespace PermissionPaladin.Domain.Users.Customers;

public class Customer : User
{
    public string NickName { get; set; }

    public List<Product> Products { get; set; }
    public Customer()
    {
        NickName = string.Empty;
        Roles = new List<Role>();
        Products = new List<Product>();
    }
}
