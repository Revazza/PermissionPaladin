using PermissionPaladin.Domain.Roles.Permissions;
using PermissionPaladin.Persistance.Context;
using PermissionPaladin.Persistance.Repositories.Interfaces;

namespace PermissionPaladin.Persistance.Repositories;

public class PermissionRepository : GenericRepository<Permission, int>, IPermissionRepository
{

    public PermissionRepository(PermissionPaladinDbContext context) : base(context)
    {
    }
}

