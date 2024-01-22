using PermissionPaladin.Domain.Roles;

namespace PermissionPaladin.Infrastructure.Repositories.Interfaces;

public interface IRoleRepository : IGenericRepository<Role, int>
{
    Task<Role?> GetByNameAsync(string roleName);
    Task<bool> RoleExistsAsync(string roleName);
}
