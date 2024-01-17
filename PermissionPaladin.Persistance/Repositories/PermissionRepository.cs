using Microsoft.EntityFrameworkCore;
using PermissionPaladin.Domain.Roles.Permissions;
using PermissionPaladin.Persistance.Context;
using PermissionPaladin.Persistance.Interfaces;

namespace PermissionPaladin.Persistance.Repositories;

public class PermissionRepository : GenericRepository<Permission, int>, IPermissionRepository
{
    public PermissionRepository(PermissionPaladinDbContext context) : base(context)
    {
    }

    public async Task<List<Permission>> GetUserPermissionsAsync(int userId)
    {
        return await _context
            .Users
            .Where(u => u.Id == userId)
            .SelectMany(u => u.Roles.SelectMany(r => r.Permissions))
            .Distinct()
            .ToListAsync();
    }
}
