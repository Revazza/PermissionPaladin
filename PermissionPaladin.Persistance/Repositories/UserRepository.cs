using Microsoft.EntityFrameworkCore;
using PermissionPaladin.Domain.Users;
using PermissionPaladin.Persistance.Context;
using PermissionPaladin.Persistance.Interfaces;

namespace PermissionPaladin.Persistance.Repositories;

public class UserRepository : GenericRepository<User, int>, IUserRepository
{
    public UserRepository(PermissionPaladinDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByIdWithRolesAsync(int id)
    {
        return await _context
            .Users
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
