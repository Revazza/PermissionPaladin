using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PermissionPaladin.Persistance.Context;
using PermissionPaladin.Persistance.Interfaces;
using PermissionPaladin.Persistance.Repositories;
using PermissionPaladin.Persistance.Services;

namespace PermissionPaladin.Persistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        return services
            .AddDatabase(configuration)
            .AddRepositories();
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

    private static IServiceCollection AddDatabase(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        return services.AddDbContext<PermissionPaladinDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(PermissionPaladinDbContext.SectionName));
        }); ;
    }

}
