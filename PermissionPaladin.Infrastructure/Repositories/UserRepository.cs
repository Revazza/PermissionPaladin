using Microsoft.EntityFrameworkCore;
using PermissionPaladin.Domain.Users;
using PermissionPaladin.Infrastructure.Repositories.Interfaces;
using PermissionPaladin.Persistance.Context;

namespace PermissionPaladin.Infrastructure.Repositories;

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
