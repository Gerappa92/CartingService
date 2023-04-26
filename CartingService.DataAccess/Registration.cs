using CartingService.DataAccess.Options;
using CartingService.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CartingService.DataAccess;

public static class Registration
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DataAccessOptions>(configuration.GetSection(DataAccessOptions.Position));
        services.AddSingleton<ICartRepository, CartRepository>();
        return services;
    }
}