using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PermissionPaladin.Infrastructure.Caching.Behaviour;
using PermissionPaladin.Infrastructure.Caching.Interfaces;
using PermissionPaladin.Infrastructure.Services.Interfaces;
using PermissionPaladin.Infrastructure.Services;
using System.ComponentModel;
using PermissionPaladin.Infrastructure.Repositories.Interfaces;
using PermissionPaladin.Infrastructure.Repositories;
using PermissionPaladin.Infrastructure.Caching.Services;

namespace PermissionPaladin.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        return services.AddCustomServices()
            .AddRepositories();
    }

    private static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        return services
            .AddMemoryCache()
            .AddTransient<IUserService, UserService>()
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(QueryCachingBehaviour<,>))
            .AddSingleton<ICachingService, CachingService>();

    }

    private static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
        return services
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IPermissionRepository, PermissionRepository>()
            .AddScoped<IRoleRepository, RoleRepository>()
            .AddScoped<IManagerRepository, ManagerRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<ICustomerRepository, CustomerRepository>();
    }

    private static IServiceCollection AddCustomerSettings(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        return services;
    }

}
