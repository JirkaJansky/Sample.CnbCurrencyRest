using System.Reflection;
using Sample.CnbCurrencyRest.API.BehaviorConfig;

namespace Sample.CnbCurrencyRest.API.ServiceRegistration;

public static class ApiServiceCollectionExtension
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers(options => options.Filters.Add(typeof(ApiExceptionFilter)));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddApplicationMapperProfiles();

        return services;
    }

    private static IServiceCollection AddApplicationMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}