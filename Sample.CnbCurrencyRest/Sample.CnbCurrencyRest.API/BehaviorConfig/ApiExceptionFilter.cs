using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Sample.CnbCurrencyRest.API.Dtos.Errors;
using Sample.CnbCurrencyRest.Domain.Common.Exceptions;
using System;
using System.Net;

namespace Sample.CnbCurrencyRest.API.BehaviorConfig;

public class ApiExceptionFilter : IExceptionFilter, IFilterMetadata
{
    private readonly ILogger<ApiExceptionFilter> _logger;

    public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        (HttpStatusCode statusCode, ErrorDto errorDto) apiErrors = this.GetApiErrors(context);
        HttpStatusCode statusCode = apiErrors.statusCode;
        context.Result = (IActionResult)new ObjectResult((object)apiErrors.errorDto)
        {
            StatusCode = new int?((int)statusCode)
        };
        context.ExceptionHandled = true;
    }

    private (HttpStatusCode statusCode, ErrorDto) GetApiErrors(ExceptionContext context)
    {
        Exception exception = context.Exception;

        var result = context.Exception switch
        {
            FluentValidation.ValidationException validationException =>
                (HttpStatusCode.BadRequest,
                    new ErrorDto
                    {
                        Message = validationException.Message, 
                        RawExcemption = validationException.ToString(),
                        Details = validationException.Errors.Any() ?
                            (ICollection<IDictionary<string, object?>>?)validationException
                                .Errors
                                .Select(failure => new Dictionary<string, object?>
                                {
                                    { nameof(failure.PropertyName), failure.PropertyName },
                                    { nameof(failure.ErrorMessage), failure.ErrorMessage}
                                })
                                .ToArray()
                            :
                            null
                    }),
            CnbCurrencyRestBaseException cnbCurrencyRestBaseException =>
                (HttpStatusCode.Conflict,
                new ErrorDto
                {
                    Message = cnbCurrencyRestBaseException.Message,
                    RawExcemption = cnbCurrencyRestBaseException.ToString(),
                    Details = cnbCurrencyRestBaseException.Details
                }),
            Exception ex => 
                (HttpStatusCode.InternalServerError,
                    new ErrorDto
                    {
                        Message = "Unhandled exception", 
                        RawExcemption = ex.ToString()
                    }
                ),
        };

        _logger.LogError(exception, result.Item2.Message, result.Item2);

        return result;
    }
}
