using PermissionPaladin.Domain.Users.Customers;
using PermissionPaladin.Domain.Users.Managers;

namespace PermissionPaladin.Persistance.Interfaces;

public interface ICustomerRepository : IGenericRepository<Customer, int>
{
}
