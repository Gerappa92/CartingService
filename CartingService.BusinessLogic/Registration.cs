using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using CartingService.BusinessLogic.Handlers;
using CartingService.BusinessLogic.Validators;

namespace CartingService.BusinessLogic;

public static class Registration
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient<IValidator<UpdateItemRequest>, UpdateItemRequestValidator>();
        return services;
    }
}