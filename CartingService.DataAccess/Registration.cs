using CartingService.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CartingService.DataAccess;

public static class Registration
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services.AddSingleton<ICartRepository, CartRepository>();
        return services;
    }
}