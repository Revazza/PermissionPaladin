using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PermissionPaladin.Application.Authentication.Handlers;
using PermissionPaladin.Application.Authentication.Models;
using PermissionPaladin.Application.Authentication.Providers;
using PermissionPaladin.Application.Authentication.Services;
using PermissionPaladin.Application.Services;
using System.Text;

namespace PermissionPaladin.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        return services
            .ConfigureAuthentication(configuration)
            .AddAuthorization()
            .AddCustomSettings(configuration)
            .AddCustomServices();
    }

    private static IServiceCollection AddCustomServices(
        this IServiceCollection services)
    {
        return services
            .AddHttpContextAccessor()
            .AddTransient<IJwtTokenGenerator, JwtTokenGenerator>()
            .AddTransient<IUserService, UserService>()
            .AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>()
            .AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

    }

    private static IServiceCollection AddCustomSettings(
       this IServiceCollection services,
       ConfigurationManager configuration)
    {
        return services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
    }

    private static IServiceCollection ConfigureAuthentication(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var issuer = configuration[$"{JwtSettings.SectionName}:Issuer"]!;
        var audience = configuration[$"{JwtSettings.SectionName}:Audience"]!;
        var secretKey = configuration[$"{JwtSettings.SectionName}:SecretKey"]!;

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = tokenValidationParameters;
            });
        return services;
    }

}
