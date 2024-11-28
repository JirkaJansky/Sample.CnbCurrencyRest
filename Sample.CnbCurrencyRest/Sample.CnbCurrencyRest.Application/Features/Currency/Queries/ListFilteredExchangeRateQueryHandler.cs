using MediatR;
using Sample.CnbCurrencyRest.Domain.Models;

namespace Sample.CnbCurrencyRest.Application.Features.Currency.Queries;

public class ListFilteredExchangeRateQueryHandler : IRequestHandler<ListFilteredExchangeRateQuery, ICollection<ExchangeRateData>>
{
    public Task<ICollection<ExchangeRateData>> Handle(ListFilteredExchangeRateQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}