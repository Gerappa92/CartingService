using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CartingService.BusinessLogic;

public static class Registration
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}