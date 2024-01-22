using PermissionPaladin.Domain.Users;
using PermissionPaladin.Domain.Users.Customers;

namespace PermissionPaladin.Domain.Products;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public Product()
    {
        Name = string.Empty;
        Customer = null!;
    }

}
