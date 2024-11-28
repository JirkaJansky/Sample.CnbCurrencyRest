namespace Sample.CnbCurrencyRest.Infrastructure.Interfaces;

public interface ICnbExchangeRateClient
{
    Task<Stream> GetCvsCurrencyDataByDateAsync(DateTime date, CancellationToken cancellationToken);
}