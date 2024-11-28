using MediatR;

namespace Sample.CnbCurrencyRest.Application.Features.Currency.Queries;

public class ListFilteredExchangeRateQuery : IRequest<ICollection<Domain.Models.ExchangeRateData>>
{
    public DateTime CurrencyTableDate { get; set; }
}