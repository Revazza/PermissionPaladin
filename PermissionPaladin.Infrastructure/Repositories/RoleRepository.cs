using Microsoft.EntityFrameworkCore;
using PermissionPaladin.Domain.Roles;
using PermissionPaladin.Infrastructure.Repositories.Interfaces;
using PermissionPaladin.Persistance.Context;

namespace PermissionPaladin.Infrastructure.Repositories;

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
