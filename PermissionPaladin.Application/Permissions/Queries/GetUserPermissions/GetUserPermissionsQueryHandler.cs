using MediatR;
using PermissionPaladin.Application.Users.Queries.GetUserById;
using PermissionPaladin.Application.Users.Queries.GetUserRoles;
using PermissionPaladin.Domain.Roles;
using PermissionPaladin.Domain.Roles.Permissions;
using PermissionPaladin.Domain.Users;

namespace PermissionPaladin.Application.Permissions.Queries.GetUserPermissions;

public class GetUserPermissionsQueryHandler : IRequestHandler<GetUserPermissionsQuery, IEnumerable<Permission>>
{
    private readonly ISender _mediator;

    public GetUserPermissionsQueryHandler(
        ISender mediator)
    {
        _mediator = mediator;
    }


    public async Task<IEnumerable<Permission>> Handle(GetUserPermissionsQuery request, CancellationToken cancellationToken)
    {
        var user = await GetUserByIdAsync(request, cancellationToken);

        if (user is null)
        {
            return Array.Empty<Permission>().ToList();
        }

        var userRoles = await GetUserRolesWithPermissionsAsync(user, cancellationToken);

        return GetDistinctUserPermissions(userRoles);
    }

    private static IEnumerable<Permission> GetDistinctUserPermissions(List<Role> roles)
    {
        return roles
            .SelectMany(role => role.Permissions)
            .Distinct();
    }

    private async Task<List<Role>> GetUserRolesWithPermissionsAsync(User user, CancellationToken cancellationToken)
        => await _mediator.Send(new GetUserRolesQuery(user, WithPermissions: true), cancellationToken);

    private async Task<User?> GetUserByIdAsync(GetUserPermissionsQuery request, CancellationToken cancellationToken)
        => await _mediator.Send(new GetUserByIdQuery(request.UserId), cancellationToken);

}
