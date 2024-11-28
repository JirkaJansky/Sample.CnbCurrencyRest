using AutoMapper;
using Sample.CnbCurrencyRest.API.Dtos;
using Sample.CnbCurrencyRest.Domain.Models;

namespace Sample.CnbCurrencyRest.API.MappingProfiles;

public class ExchangeRateDataDtoMapProfile : Profile
{
    public ExchangeRateDataDtoMapProfile()
    {
        CreateMap<ExchangeRateDataModel, ExchangeRateDataDto>();
    }
}
