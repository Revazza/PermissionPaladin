
namespace PermissionPaladin.Application.Customers.Dtos;

public class CustomerDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string NickName { get; set; }

    public CustomerDto()
    {
        UserName = string.Empty;
        NickName = string.Empty;
    }

}
