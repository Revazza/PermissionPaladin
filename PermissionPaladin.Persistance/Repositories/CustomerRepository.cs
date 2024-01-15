using PermissionPaladin.Domain.Users.Customers;
using PermissionPaladin.Persistance.Context;
using PermissionPaladin.Persistance.Interfaces;

namespace PermissionPaladin.Persistance.Repositories;

internal class CustomerRepository : GenericRepository<Customer, int>, ICustomerRepository
{
    public CustomerRepository(PermissionPaladinDbContext context) : base(context)
    {
    }
}
