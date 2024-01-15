using PermissionPaladin.Domain.Roles.Permissions;
using PermissionPaladin.Domain.Users;
using PermissionPaladin.Persistance.Context;
using PermissionPaladin.Persistance.Interfaces;

namespace PermissionPaladin.Persistance.Repositories;

public class UserRepository : GenericRepository<User, int>, IUserRepository
{
    public UserRepository(PermissionPaladinDbContext context) : base(context)
    {
    }

}
