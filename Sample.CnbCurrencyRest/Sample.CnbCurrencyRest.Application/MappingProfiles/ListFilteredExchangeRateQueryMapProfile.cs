using AutoMapper;
using Sample.CnbCurrencyRest.Application.Features.Currency.Queries;
using Sample.CnbCurrencyRest.Domain.Models.Filters;

namespace Sample.CnbCurrencyRest.Application.MappingProfiles;
public class ListFilteredExchangeRateQueryMapProfile : Profile
{
    public ListFilteredExchangeRateQueryMapProfile()
    {
        CreateMap<ListFilteredExchangeRateQuery, ExchangeRateDataFilter>();
    }
}
