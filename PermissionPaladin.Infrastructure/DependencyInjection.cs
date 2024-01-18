using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PermissionPaladin.Infrastructure.Caching;
using PermissionPaladin.Infrastructure.Caching.Behaviour;
using PermissionPaladin.Infrastructure.Caching.Interfaces;

namespace PermissionPaladin.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        return services.AddCustomServices();
    }

    private static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        return services
            .AddMemoryCache()
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(QueryCachingBehaviour<,>))
            .AddSingleton<ICachingService, CachingService>();

    }

    private static IServiceCollection AddCustomerSettings(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        return services;
    }

}
