using AutoMapper;
using Sample.CnbCurrencyRest.Domain.Models;
using Sample.CnbCurrencyRest.Infrastructure.Models;

namespace Sample.CnbCurrencyRest.Infrastructure.MappingProfiles;
public class PaginatedListModelMapProfile : Profile
{
    public PaginatedListModelMapProfile()
    {
        CreateMap(typeof(PaginatedListModel<>), typeof(PaginatedListModel<>))
            .ConvertUsing(typeof(PaginatedListConverter<,>));
    }

    public class PaginatedListConverter<TSource, TDestination> : ITypeConverter<PaginatedListModel<TSource>, PaginatedListModel<TDestination>>
    {
        public PaginatedListModel<TDestination> Convert(PaginatedListModel<TSource> source, PaginatedListModel<TDestination> destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            var destinationList = source.Items.Select(item => context.Mapper.Map<TDestination>(item)).ToList();
            return new PaginatedListModel<TDestination>(destinationList, source.TotalCount, source.PageIndex, source.PageSize);
        }
    }
}
