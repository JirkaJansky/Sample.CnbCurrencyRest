using Sample.CnbCurrencyRest.API.ServiceRegistration;
using Sample.CnbCurrencyRest.Application.ServiceRegistration;
using Sample.CnbCurrencyRest.Domain.Common.Helpers;
using Sample.CnbCurrencyRest.Infrastructure.ServiceRegistration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddApi()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();
ConfigurationValidator.EnsureIsValid();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();