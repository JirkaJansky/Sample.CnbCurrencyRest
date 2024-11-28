using Sample.CnbCurrencyRest.Domain.Models;

namespace Sample.CnbCurrencyRest.Infrastructure.Interfaces;

public interface ICnbCurrencyService
{
    Task<ICollection<ExchangeRateData>> GetCurrencyForDate(DateTime date, CancellationToken cancellationToken);
}