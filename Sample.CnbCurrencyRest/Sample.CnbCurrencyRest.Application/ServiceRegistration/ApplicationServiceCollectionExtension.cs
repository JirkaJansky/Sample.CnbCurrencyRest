using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using Sample.CnbCurrencyRest.Application.Config;
using System.Reflection;

namespace Sample.CnbCurrencyRest.Application.ServiceRegistration;

public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            .AddServices()
            .AddMediatRWithBehaviors()
            .AddApplicationMapperProfiles();

        return services;
    }

    private static IServiceCollection AddApplicationMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IClock>(SystemClock.Instance);
        return services;
    }

    private static IServiceCollection AddMediatRWithBehaviors(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}