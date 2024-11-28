namespace Sample.CnbCurrencyRest.Infrastructure.Interfaces;

public interface ICnbCurrencyClient
{
    Task<Stream> GetCvsCurrencyDataByDate(DateTime date);
}