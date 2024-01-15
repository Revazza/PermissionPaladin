using Microsoft.AspNetCore.Authorization;

namespace PermissionPaladin.Application.Authentication.Models;

public class PermissionRequirement : IAuthorizationRequirement
{
    public string Permission { get; set; }

    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }

}
