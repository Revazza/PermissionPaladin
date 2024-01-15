using PermissionPaladin.Domain.Users.Managers;
using PermissionPaladin.Persistance.Context;
using PermissionPaladin.Persistance.Interfaces;

namespace PermissionPaladin.Persistance.Repositories;

public class ManagerRepository : GenericRepository<Manager, int>, IManagerRepository
{
    public ManagerRepository(PermissionPaladinDbContext context) : base(context)
    {
    }
}
