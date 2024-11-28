using FluentValidation;
using Sample.CnbCurrencyRest.Application.Common.Validators;

namespace Sample.CnbCurrencyRest.Application.Features.Currency.Queries;

public class ListFilteredExchangeRateQueryValidator : AbstractValidator<ListFilteredExchangeRateQuery>
{
    public ListFilteredExchangeRateQueryValidator()
    {
        this.SetupPaginationRules();

        RuleFor(query => query.ExchangeDataFromDate)
            .NotEmpty()
            .When(query => query.ExchangeDataFromDate != null);

        RuleFor(query => query.ExchangeRateFrom)
            .GreaterThan(0)
            .When(query => query.ExchangeRateFrom != null);

        RuleFor(query => query.ExchangeRateTo)
            .GreaterThan(0)
            .When(query => query.ExchangeRateTo != null);

        RuleFor(command => command)
            .Must(command => command.ExchangeRateTo > command.ExchangeRateFrom)
            .When(command => command.ExchangeRateTo != null && command.ExchangeRateFrom != null)
            .OverridePropertyName("ExchangeRateTo")
            .WithMessage("'ExchangeRateTo' must be greater than 'ExchangeRateFrom'");

    }
}