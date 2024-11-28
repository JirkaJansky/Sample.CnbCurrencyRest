namespace Sample.CnbCurrencyRest.Domain.Models.Filters;

public class PaginatedListFilter
{
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
    public bool? GetAllInOnePage { get; set; }
}
