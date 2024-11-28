using Sample.CnbCurrencyRest.Domain.Models;
using Sample.CnbCurrencyRest.Domain.Models.Filters;

namespace Sample.CnbCurrencyRest.Domain.Common.Interfaces.Services;

public interface ICnbExchangeRateService
{
    Task<ICollection<ExchangeRateDataModel>> GetListExchangeDataForDateAsync(DateTime date, CancellationToken cancellationToken);
    Task<PaginatedListModel<ExchangeRateDataModel>> GetFilteredCurrencyForDatePageAsync(ExchangeRateDataFilter filter, CancellationToken cancellationToken);
}