using PermissionPaladin.Domain.Roles.Permissions;
using PermissionPaladin.Infrastructure.Repositories.Interfaces;
using PermissionPaladin.Persistance.Context;

namespace PermissionPaladin.Infrastructure.Repositories;

public class PermissionRepository : GenericRepository<Permission, int>, IPermissionRepository
{

    public PermissionRepository(PermissionPaladinDbContext context) : base(context)
    {
    }
}

