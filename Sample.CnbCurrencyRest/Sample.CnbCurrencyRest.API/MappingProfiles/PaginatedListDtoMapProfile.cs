using AutoMapper;
using Sample.CnbCurrencyRest.API.Dtos;
using Sample.CnbCurrencyRest.Domain.Models;

namespace Sample.CnbCurrencyRest.API.MappingProfiles;

public class PaginatedListDtoMapProfile : Profile
{
    public PaginatedListDtoMapProfile()
    {
        CreateMap(typeof(PaginatedListModel<>), typeof(PaginatedListDto<>));
    }
}
