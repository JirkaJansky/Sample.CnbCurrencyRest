namespace Sample.CnbCurrencyRest.Domain.Models.Filters;
public class ExchangeRateDataFilter : PaginatedListFilter
{
    public DateTime ExchangeDataFromDate { get; set; }
    public decimal? ExchangeRateFrom { get; set; }
    public decimal? ExchangeRateTo { get; set; }
    public string? CodeSearch { get; set; }
    public string? CurrencyNameSearch { get; set; }
    public string? CountryCodeSearch { get; set; }
}
