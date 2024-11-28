using AutoMapper;
using MediatR;
using NodaTime;
using Sample.CnbCurrencyRest.Domain.Common.Interfaces.Services;
using Sample.CnbCurrencyRest.Domain.Models;
using Sample.CnbCurrencyRest.Domain.Models.Filters;

namespace Sample.CnbCurrencyRest.Application.Features.Currency.Queries;

public class ListFilteredExchangeRateQueryHandler : IRequestHandler<ListFilteredExchangeRateQuery, PaginatedListModel<ExchangeRateDataModel>>
{
    private readonly ICnbExchangeRateService _cnbExchangeRateService;
    private readonly IMapper _mapper;
    private readonly IClock _clock;

    public ListFilteredExchangeRateQueryHandler(ICnbExchangeRateService cnbExchangeRateService, IMapper mapper, IClock clock)
    {
        _cnbExchangeRateService = cnbExchangeRateService;
        _mapper = mapper;
        _clock = clock;
    }

    public async Task<PaginatedListModel<ExchangeRateDataModel>> Handle(ListFilteredExchangeRateQuery request, CancellationToken cancellationToken)
    {
        request.ExchangeDataFromDate = request.ExchangeDataFromDate ?? _clock.GetCurrentInstant().ToDateTimeUtc();

        return await _cnbExchangeRateService
            .GetFilteredCurrencyForDatePageAsync(
                _mapper.Map<ExchangeRateDataFilter>(request), 
                cancellationToken
            );
    }
}