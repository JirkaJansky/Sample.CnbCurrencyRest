namespace Sample.CnbCurrencyRest.API.Dtos.Errors;

public class ErrorDto
{
    public string Message { get; set; }
    public ICollection<IDictionary<string, object?>>? Details { get; set; }
    public string RawExcemption { get; set; }
}

