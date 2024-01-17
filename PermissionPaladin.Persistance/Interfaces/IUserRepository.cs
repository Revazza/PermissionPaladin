using PermissionPaladin.Domain.Users;

namespace PermissionPaladin.Persistance.Interfaces;

public interface IUserRepository : IGenericRepository<User, int>
{
    Task<User?> GetByIdWithRolesAsync(int id);
}
