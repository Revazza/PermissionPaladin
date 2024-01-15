using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PermissionPaladin.Application.Services;

public interface IUserService
{
    int GetCurrentUserId();
}

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetCurrentUserId()
    {
        if (_httpContextAccessor.HttpContext?.User.Identity is not ClaimsIdentity identity)
        {
            throw new UnauthorizedAccessException("User identity not available in the current context");
        }

        var userId = identity.Claims.FirstOrDefault(c => c.Properties.Any(p => p.Value == JwtRegisteredClaimNames.Sub))?.Value;

        if (!int.TryParse(userId, out int parsedUserId))
        {
            throw new UnauthorizedAccessException($"Unable to parse UserId '{userId}'");
        }

        return parsedUserId;
    }

}
