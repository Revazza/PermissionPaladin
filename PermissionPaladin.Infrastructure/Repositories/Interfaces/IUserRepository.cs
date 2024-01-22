using PermissionPaladin.Domain.Users;

namespace PermissionPaladin.Infrastructure.Repositories.Interfaces;

public interface IUserRepository : IGenericRepository<User, int>
{
    Task<User?> GetByIdWithRolesAsync(int id);
}
