using Sample.CnbCurrencyRest.Infrastructure.Interfaces;

namespace Sample.CnbCurrencyRest.Infrastructure.Clients;

public class CnbExchangeRateClient(string baseUrl, HttpClient client) : ICnbExchangeRateClient
{
    public Task<Stream> GetCvsCurrencyDataByDateAsync(DateTime date, CancellationToken cancellationToken)
    {
        Uri uri = new Uri($"{baseUrl.TrimEnd('/')}?date={date.ToString("dd.MM.yyyy")}");
        return client.GetStreamAsync(uri, cancellationToken);
    }
}