using MediatR;
using PermissionPaladin.Domain.Roles.Permissions;
using PermissionPaladin.Infrastructure.Caching.Interfaces;

namespace PermissionPaladin.Application.Permissions.Queries.GetUserPermissions;

public record GetUserPermissionsQuery(int UserId) : IRequest<List<Permission>>, ICacheableQuery
{
    public string SectionName => "UserPermissions";

    public string Salt { get; set; } = UserId.ToString();
}
