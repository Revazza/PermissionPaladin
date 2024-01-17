using PermissionPaladin.Domain.Roles.Permissions;

namespace PermissionPaladin.Persistance.Interfaces;

public interface IPermissionRepository : IGenericRepository<Permission, int>
{
    Task<List<Permission>> GetUserPermissionsAsync(int userId);
}
