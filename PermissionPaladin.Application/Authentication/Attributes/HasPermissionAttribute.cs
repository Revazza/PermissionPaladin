using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using PermissionPaladin.Domain.Enums;

namespace PermissionPaladin.Application.Authentication.Attributes;

/// <summary>
/// Attribute for specifying authorization based on a specific access permission
/// </summary>
public class HasPermissionAttribute : AuthorizeAttribute
{
    /// <summary>
    /// Initializes a new instance of the HasPermissionAttribute class
    /// </summary>
    /// <param name="permission">The access permission required for authorization</param>
    public HasPermissionAttribute(AccessPermissions permission)
        : base(policy: permission.ToString())
    {
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
    }
}