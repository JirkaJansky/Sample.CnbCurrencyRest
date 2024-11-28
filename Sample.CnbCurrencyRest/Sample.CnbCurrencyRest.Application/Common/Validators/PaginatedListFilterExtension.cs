using FluentValidation;
using Sample.CnbCurrencyRest.Domain.Models.Filters;

namespace Sample.CnbCurrencyRest.Application.Common.Validators;

public static class PaginatedListFilterExtension
{
    public static void SetupPaginationRules<T>(this AbstractValidator<T> item) where T : PaginatedListFilter
    {
        item.When(command => command.GetAllInOnePage != null, () =>
        {
            item.When(command => command.GetAllInOnePage.Value, () =>
                {
                    item.RuleFor(q => q.PageIndex)
                        .Null()
                        .WithMessage($"Cannot use {nameof(PaginatedListFilter.PageIndex)} parameter" +
                                     $", when parameter {nameof(PaginatedListFilter.GetAllInOnePage)} is used.");

                    item.RuleFor(q => q.PageSize)
                        .Null()
                        .WithMessage($"Cannot use {nameof(PaginatedListFilter.PageSize)} parameter" +
                                     $", when parameter {nameof(PaginatedListFilter.GetAllInOnePage)} is used.");
                })
                .Otherwise(() =>
                {
                    item.RuleFor(q => q.PageIndex).NotNull().GreaterThanOrEqualTo(0);
                    item.RuleFor(q => q.PageSize).NotNull().GreaterThan(0);
                });
        })
        .Otherwise(() =>
        {
            item.When(command => command.PageIndex.HasValue || command.PageSize.HasValue, () =>
            {
                item.RuleFor(q => q.PageIndex).NotNull().GreaterThanOrEqualTo(0);
                item.RuleFor(q => q.PageSize).NotNull().GreaterThan(0);
            });
        });
    }
    
}
