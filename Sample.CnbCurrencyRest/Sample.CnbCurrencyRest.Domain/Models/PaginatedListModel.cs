namespace Sample.CnbCurrencyRest.Domain.Models;

public class PaginatedListModel<T>
{
    public PaginatedListModel(List<T> items, int count, int pageIndex, int pageSize)
    {
        if (pageSize <= 0)
        {
            throw new Exception("Page size must be greater than zero");
        }

        if (pageIndex < 0)
        {
            throw new Exception("Page index must be greater or equal than zero");
        }

        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
        PageSize = pageSize;
        Items = items;
    }

    public IReadOnlyList<T> Items { get; }
    public int PageIndex { get; }
    public int PageSize { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }

    public bool HasPreviousPage => PageIndex > 0;
    public bool HasNextPage => PageIndex + 1 < TotalPages;
}
