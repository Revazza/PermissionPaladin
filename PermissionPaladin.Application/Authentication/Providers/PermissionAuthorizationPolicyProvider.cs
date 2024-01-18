using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using PermissionPaladin.Application.Authentication.Models;

namespace PermissionPaladin.Application.Authentication.Providers;

/// <summary>
/// Custom authorization policy provider that includes permissions-based policies
/// </summary>
public class PermissionAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
{
    /// <summary>
    /// Initializes a new instance of the PermissionAuthorizationPolicyProvider class
    /// </summary>
    /// <param name="options">The options for authorization</param>
    public PermissionAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
    {
    }

    /// <summary>
    /// Gets or creates the authorization policy asynchronously based on the provided policy name
    /// </summary>
    /// <param name="policyName">The name of the policy to retrieve</param>
    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var policy = await base.GetPolicyAsync(policyName);

        if (policy is not null)
        {
            return policy;
        }

        return new AuthorizationPolicyBuilder()
            .AddRequirements(new PermissionRequirement(policyName))
            .Build();
    }
}