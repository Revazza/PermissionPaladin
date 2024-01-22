using PermissionPaladin.Domain.Users.Managers;
using PermissionPaladin.Infrastructure.Repositories.Interfaces;
using PermissionPaladin.Persistance.Context;

namespace PermissionPaladin.Infrastructure.Repositories;

public class ManagerRepository : GenericRepository<Manager, int>, IManagerRepository
{
    public ManagerRepository(PermissionPaladinDbContext context) : base(context)
    {
    }
}
