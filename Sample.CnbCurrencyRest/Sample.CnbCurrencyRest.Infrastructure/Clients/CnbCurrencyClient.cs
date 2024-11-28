using Sample.CnbCurrencyRest.Infrastructure.Interfaces;

namespace Sample.CnbCurrencyRest.Infrastructure.Clients;

public class CnbCurrencyClient(string baseUrl, HttpClient client) : ICnbCurrencyClient
{
    public Task<Stream> GetCvsCurrencyDataByDate(DateTime date)
    {
        Uri uri = new Uri($"{baseUrl.TrimEnd('/')}?date={date.ToString("dd.MM.yyyy")}");
        return client.GetStreamAsync(uri);
    }
}