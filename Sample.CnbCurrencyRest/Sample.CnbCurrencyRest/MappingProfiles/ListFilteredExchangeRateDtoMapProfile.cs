using AutoMapper;
using Sample.CnbCurrencyRest.API.Dtos.QueryParams;
using Sample.CnbCurrencyRest.Application.Features.Currency.Queries;

namespace Sample.CnbCurrencyRest.API.MappingProfiles;

public class ListFilteredExchangeRateDtoMapProfile : Profile
{
    public ListFilteredExchangeRateDtoMapProfile()
    {
        CreateMap<ListFilteredExchangeRateDto, ListFilteredExchangeRateQuery>();
    }
}
