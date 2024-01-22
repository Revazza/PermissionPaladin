using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using PermissionPaladin.Application.Authentication.Models;
using PermissionPaladin.Application.Permissions.Queries.GetUserPermissions;
using PermissionPaladin.Domain.Roles.Permissions;
using PermissionPaladin.Infrastructure.Services.Interfaces;

namespace PermissionPaladin.Application.Authentication.Handlers;

/// <summary>
/// Authorization handler responsible for checking user permissions based on requirements
/// </summary>
public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IUserService _userService;

    /// <summary>
    /// Initializes a new instance of the PermissionAuthorizationHandler class
    /// </summary>
    /// <param name="serviceScopeFactory">The service scope factory for creating scoped service instances</param>
    /// <param name="userService">The user service for accessing user-related information</param>
    public PermissionAuthorizationHandler(
        IServiceScopeFactory serviceScopeFactory,
        IUserService userService)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _userService = userService;
    }

    /// <summary>
    /// Handles the authorization requirement asynchronously
    /// </summary>
    /// <param name="context">The authorization context</param>
    /// <param name="requirement">The permission requirement</param>
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

    private async Task<IEnumerable<Permission>> GetUserPermissionsAsync()
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();
        return await mediator.Send(new GetUserPermissionsQuery(_userService.GetCurrentUserId()));
    }

    private static bool HasPermission(IEnumerable<Permission> permissions, string requiredPermission)
        => permissions.Any(x => x.Name == requiredPermission);
}
