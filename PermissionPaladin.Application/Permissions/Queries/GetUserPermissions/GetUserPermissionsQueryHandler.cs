using MediatR;
using PermissionPaladin.Domain.Roles.Permissions;
using PermissionPaladin.Persistance.Repositories.Interfaces;

namespace PermissionPaladin.Application.Permissions.Queries.GetUserPermissions;

public class GetUserPermissionsQueryHandler : IRequestHandler<GetUserPermissionsQuery, List<Permission>>
{
    private readonly IPermissionRepository _permissionRepository;

    public GetUserPermissionsQueryHandler(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<List<Permission>> Handle(GetUserPermissionsQuery request, CancellationToken cancellationToken)
    {
        return await _permissionRepository.GetUserPermissionsAsync(request.UserId);
    }
}
