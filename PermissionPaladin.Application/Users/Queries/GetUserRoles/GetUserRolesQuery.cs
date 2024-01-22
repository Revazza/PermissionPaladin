using MediatR;
using PermissionPaladin.Domain.Roles;
using PermissionPaladin.Domain.Users;

namespace PermissionPaladin.Application.Users.Queries.GetUserRoles;

public record GetUserRolesQuery(User User, bool WithPermissions = false, bool AsTracking = false) : IRequest<List<Role>>;
