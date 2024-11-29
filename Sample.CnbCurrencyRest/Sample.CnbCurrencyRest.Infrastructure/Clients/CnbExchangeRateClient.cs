using Sample.CnbCurrencyRest.Domain.Common.Exceptions;
using Sample.CnbCurrencyRest.Infrastructure.Interfaces;

namespace Sample.CnbCurrencyRest.Infrastructure.Clients;

public class CnbExchangeRateClient(string baseUrl, HttpClient client) : ICnbExchangeRateClient
{
    public async Task<Stream> GetCvsCurrencyDataByDateAsync(DateTime date, CancellationToken cancellationToken)
    {
        try
        {
            Uri uri = new Uri($"{baseUrl.TrimEnd('/')}?date={date.ToString("dd.MM.yyyy")}");
            return await client.GetStreamAsync(uri, cancellationToken);
        }
        catch (Exception exception)
        {
            throw new CnbClientException($"Error in call {nameof(CnbExchangeRateClient)}", innerException: exception);
        }

    }
}