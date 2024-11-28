namespace Sample.CnbCurrencyRest.API.Dtos.QueryParams;

public class PaginatedListFilterDto
{
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
    public bool? GetAllInOnePage { get; set; }
}
