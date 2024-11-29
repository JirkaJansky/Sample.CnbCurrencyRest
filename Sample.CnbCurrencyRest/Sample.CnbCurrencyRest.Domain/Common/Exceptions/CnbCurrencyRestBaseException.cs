namespace Sample.CnbCurrencyRest.Domain.Common.Exceptions;
public class CnbCurrencyRestBaseException : Exception
{
    public CnbCurrencyRestBaseException(string message, ICollection<IDictionary<string, object?>>? details, Exception? innerException) : base(message, innerException)
    {
        Details = details;
    }
    public ICollection<IDictionary<string, object?>>? Details { get; private set; }
}

public class CnbClientException : CnbCurrencyRestBaseException
{
    public CnbClientException(string message, ICollection<IDictionary<string, object?>>? details = null, Exception? innerException = null) 
        : base(message, details,innerException) 
    {

    }
}

public class CnbCsvReaderException : CnbCurrencyRestBaseException
{
    public CnbCsvReaderException(string message, ICollection<IDictionary<string, object?>>? details = null, Exception? innerException = null)
        : base(message, details, innerException)
    {

    }
}