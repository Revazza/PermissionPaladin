using Microsoft.EntityFrameworkCore;
using PermissionPaladin.Domain.Roles;
using PermissionPaladin.Persistance.Context;
using PermissionPaladin.Persistance.Repositories.Interfaces;

namespace PermissionPaladin.Persistance.Repositories;

public class RoleRepository : GenericRepository<Role, int>, IRoleRepository
{
    public RoleRepository(PermissionPaladinDbContext context) : base(context)
    {
    }

    public async Task<Role?> GetByNameAsync(string roleName)
    {
        return await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
    }

    public async Task<bool> RoleExistsAsync(string roleName)
    {
        return await _context.Roles.AnyAsync(x => x.Name == roleName);
    }
}
