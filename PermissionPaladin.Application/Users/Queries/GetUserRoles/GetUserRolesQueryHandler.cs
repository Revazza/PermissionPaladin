using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PermissionPaladin.Domain.Roles;
using PermissionPaladin.Domain.Users;
using System.Threading;

namespace PermissionPaladin.Application.Users.Queries.GetUserRoles;

/// <summary>
/// Handles the GetUserRolesQuery to retrieve a list of roles based on parameters for a user
/// </summary>
public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, List<Role>>
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public GetUserRolesQueryHandler(
        UserManager<User> userManager,
        RoleManager<Role> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    /// <summary>
    /// Handles the GetUserRolesQuery and retrieves a list of roles for the specified user, based on parameters.
    /// </summary>
    /// <param name="request">The GetUserRolesQuery containing user information.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A list of roles associated with the user, based on parameters.</returns>
    public async Task<List<Role>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
    {
        var userRoleNames = await _userManager.GetRolesAsync(request.User);
        var query = _roleManager.Roles;

        query = ApplyFilters(query, request);

        var userRoles = await GetUserRolesAsync(query, userRoleNames);

        return userRoles;
    }

    private static async Task<List<Role>> GetUserRolesAsync(IQueryable<Role> query, IList<string> userRoleNames)
    {
        return await query
            .Where(role =>
                userRoleNames.Any(roleName => roleName == role.Name)
            ).ToListAsync();
    }

    private static IQueryable<Role> ApplyFilters(IQueryable<Role> query, GetUserRolesQuery request)
    {
        query = AsTrackingIfRequired(query, request.AsTracking);    
        query = IncludePermissionsIfRequired(query, request.WithPermissions);
        return query;
    }

    private static IQueryable<Role> IncludePermissionsIfRequired(IQueryable<Role> query, bool withPermissions)
        => withPermissions ? query.Include(x => x.Permissions) : query;

    private static IQueryable<Role> AsTrackingIfRequired(IQueryable<Role> query, bool asTracking)
     => asTracking ? query.AsTracking() : query;

}
