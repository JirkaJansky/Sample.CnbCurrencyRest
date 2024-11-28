using Sample.CnbCurrencyRest.Domain.Models;

namespace Sample.CnbCurrencyRest.Domain.Common.Helpers;

public static class QueryableExtensions
{
    private const int defaultPageSize = 20;

    public static PaginatedListModel<T> PaginatedList<T>(this IQueryable<T> queryable, int? pageIndex, int? pageSize, bool? getAllInOnePage = null)
    {
        if (getAllInOnePage == null && pageSize == null && pageIndex == null)
        {
            getAllInOnePage = false;
            pageSize = defaultPageSize;
            pageIndex = 0;
        }

        if (getAllInOnePage == null || !getAllInOnePage.Value)
        {
            if (!pageSize.HasValue || pageSize.Value <= 0)
            {
                throw new Exception("Page size must be greater than zero");
            }

            if (!pageIndex.HasValue || pageIndex.Value < 0)
            {
                throw new Exception("Page index must be greater or equal than zero");
            }
        }

        var count = queryable
            .Count();

        if (getAllInOnePage.HasValue && getAllInOnePage.Value)
        {
            pageIndex = 0;
            pageSize = Math.Max(count, pageSize ?? defaultPageSize);
        }
        else
        {
            queryable = queryable.Skip(pageIndex!.Value * pageSize!.Value).Take(pageSize.Value);
        }

        var items = queryable.ToList();

        return new PaginatedListModel<T>(items, count, pageIndex!.Value, pageSize!.Value);
    }
}
