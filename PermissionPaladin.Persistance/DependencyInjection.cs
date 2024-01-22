using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PermissionPaladin.Persistance.Context;

namespace PermissionPaladin.Persistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        return services
            .AddDatabase(configuration);
    }


    private static IServiceCollection AddDatabase(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        return services.AddDbContext<PermissionPaladinDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(PermissionPaladinDbContext.SectionName));
        });
    }

}
