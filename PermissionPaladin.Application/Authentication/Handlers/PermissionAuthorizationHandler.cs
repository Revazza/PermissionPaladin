using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using PermissionPaladin.Application.Authentication.Models;
using PermissionPaladin.Domain.Roles.Permissions;
using PermissionPaladin.Persistance.Interfaces;

namespace PermissionPaladin.Application.Authentication.Handlers;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public PermissionAuthorizationHandler(
        IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var permissions = await GetUserPermissionsAsync();

        if (!HasPermission(permissions, requirement.Permission))
        {
            throw new UnauthorizedAccessException("Insufficient permissions");
        }

        context.Succeed(requirement);
    }

    private async Task<List<Permission>> GetUserPermissionsAsync()
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var permissionRepository = scope.ServiceProvider.GetRequiredService<IPermissionRepository>();

        return await permissionRepository.GetUserPermissions(0);
    }

    private static bool HasPermission(List<Permission> permissions, string requiredPermission)
        => permissions.Any(x => x.Name == requiredPermission);

}
