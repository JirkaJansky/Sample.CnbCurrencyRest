using AutoMapper;
using Sample.CnbCurrencyRest.Domain.Models;
using Sample.CnbCurrencyRest.Infrastructure.Models;

namespace Sample.CnbCurrencyRest.Infrastructure.MappingProfiles;
public class CsvExchangeRateDataMapProfile : Profile
{
    public CsvExchangeRateDataMapProfile()
    {
        CreateMap<CsvExchangeRateData, ExchangeRateDataModel>();
    }
}
