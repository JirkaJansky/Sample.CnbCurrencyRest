using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sample.CnbCurrencyRest.API.Dtos.Errors;
using System.Net;

namespace Sample.CnbCurrencyRest.API.BehaviorConfig;

public class ApiExceptionFilter : IExceptionFilter, IFilterMetadata
{
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
        return context.Exception switch
        {
            FluentValidation.ValidationException validationException =>
                (HttpStatusCode.Conflict,
                    new ErrorDto
                    {
                        Message = validationException.Message, 
                        RawExcemption = validationException.ToString()
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

    }
}
