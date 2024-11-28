namespace Sample.CnbCurrencyRest.API.ServiceRegistration;

public static class ApiServiceCollectionExtension
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers(); //TODO Exception filter
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
}