using MediatR;
using Microsoft.Extensions.Logging;

namespace Sample.CnbCurrencyRest.Application.BehaviorConfigs;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        string requestName = typeof(TRequest).Name;

        TResponse response;

        _logger.LogDebug("Handling {@requestName} with request: {@request}", requestName, request);
        try
        {
            response = await next();
        }
        catch (Exception exception)
        {
            _logger.LogDebug("Handling {@requestName} failed with exception {@exception}", requestName, exception);
            throw;
        }
        _logger.LogDebug("Handled {@requestName} with response: {@response}", requestName, response);

        return response;
    }
}
