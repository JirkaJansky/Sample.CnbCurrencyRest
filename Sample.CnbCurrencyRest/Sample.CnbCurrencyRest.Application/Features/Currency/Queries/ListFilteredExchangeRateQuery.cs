using MediatR;
using Sample.CnbCurrencyRest.Domain.Models;
using Sample.CnbCurrencyRest.Domain.Models.Filters;

namespace Sample.CnbCurrencyRest.Application.Features.Currency.Queries;

public class ListFilteredExchangeRateQuery : PaginatedListFilter , IRequest<PaginatedListModel<ExchangeRateDataModel>>
{
    public DateTime? ExchangeDataFromDate { get; set; }
    public decimal? ExchangeRateFrom { get; set; }
    public decimal? ExchangeRateTo { get; set; }
    public string? CodeSearch { get; set; }
    public string? CurrencyNameSearch { get; set; }
    public string? CountryCodeSearch { get; set; }
}