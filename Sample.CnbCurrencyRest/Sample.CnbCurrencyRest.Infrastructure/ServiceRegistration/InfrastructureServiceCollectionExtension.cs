using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sample.CnbCurrencyRest.API.Options;
using Sample.CnbCurrencyRest.Domain.Extensions;
using Sample.CnbCurrencyRest.Infrastructure.Clients;
using Sample.CnbCurrencyRest.Infrastructure.Interfaces;
using Sample.CnbCurrencyRest.Infrastructure.Services;
using System.Reflection;

namespace Sample.CnbCurrencyRest.Infrastructure.ServiceRegistration;

public static class InfrastructureServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHttpClients()
            .AddServices()
            .AddCnbOptions(configuration)
            .AddApplicationMapperProfiles();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICnbCurrencyService, CnbCurrencyService>();
        return services;
    }

    private static IServiceCollection AddCnbOptions(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(CnbApiOptions.ConfigurationSection);

        services.AddOptions<CnbApiOptions>()
            .Bind(section)
            .ValidateData(section);

        return services;
    }

    private static IServiceCollection AddHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient<ICnbCurrencyClient, CnbCurrencyClient>((client, services) =>
        {
            var cnbCurrencyClient = new CnbCurrencyClient(services.GetRequiredService<IOptions<CnbApiOptions>>().Value.CnbDayCurrencyUri, client);

            return cnbCurrencyClient;
        });

        return services;
    }

    private static IServiceCollection AddApplicationMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}