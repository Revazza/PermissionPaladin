using PermissionPaladin.Domain.Users.Customers;
using PermissionPaladin.Infrastructure.Repositories.Interfaces;
using PermissionPaladin.Persistance.Context;

namespace PermissionPaladin.Infrastructure.Repositories;

internal class CustomerRepository : GenericRepository<Customer, int>, ICustomerRepository
{
    public CustomerRepository(PermissionPaladinDbContext context) : base(context)
    {
    }
}
