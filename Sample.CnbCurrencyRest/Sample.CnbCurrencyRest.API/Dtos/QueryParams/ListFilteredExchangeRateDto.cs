namespace Sample.CnbCurrencyRest.API.Dtos.QueryParams;

public class ListFilteredExchangeRateDto : PaginatedListFilterDto
{
    public DateTime? ExchangeDataFromDate { get; set; }
    public decimal? ExchangeRateFrom { get; set; }
    public decimal? ExchangeRateTo { get; set; }
    public string? CodeSearch { get; set; }
    public string? CurrencyNameSearch { get; set; }
    public string? CountryCodeSearch { get; set; }
}