using FluentValidation;

namespace Sample.CnbCurrencyRest.Application.Features.Currency.Queries;

public class ListFilteredExchangeRateQueryValidator : AbstractValidator<ListFilteredExchangeRateQuery>
{
    public ListFilteredExchangeRateQueryValidator()
    {
        RuleFor(query => query.CurrencyTableDate)
            .NotEmpty();
    }
}