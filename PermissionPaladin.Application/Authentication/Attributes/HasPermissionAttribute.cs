using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using PermissionPaladin.Domain.Enums;

namespace PermissionPaladin.Application.Authentication.Attributes;

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(Permissions permission)
        : base(policy: permission.ToString())
    {
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
    }
}
