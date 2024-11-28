namespace Sample.CnbCurrencyRest.API.Dtos;

public class PaginatedListDto<T>
{
    public IEnumerable<T> Items { get; set; } = null!;
    public int PageIndex { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }
}
