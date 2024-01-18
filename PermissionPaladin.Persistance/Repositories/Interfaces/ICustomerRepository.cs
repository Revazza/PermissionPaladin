using PermissionPaladin.Domain.Users.Customers;
using PermissionPaladin.Domain.Users.Managers;

namespace PermissionPaladin.Persistance.Repositories.Interfaces;

public interface ICustomerRepository : IGenericRepository<Customer, int>
{
}
