using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Sample.CnbCurrencyRest.Domain.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Sample.CnbCurrencyRest.Domain.Extensions;

public static class OptionsExtension
{
    public static OptionsBuilder<TOptions> ValidateData<TOptions>(this OptionsBuilder<TOptions> optionsBuilder, IConfigurationSection section) where TOptions : class
    {
        var options = (TOptions)Activator.CreateInstance(typeof(TOptions))!;
        section.Bind(options);

        var result = new List<ValidationResult>();
        if (!Validator.TryValidateObject(options, new ValidationContext(options), result, true))
        {
            foreach (var validationResult in result)
                foreach (var memberName in validationResult.MemberNames)
                    ConfigurationValidator.AddMissingConfiguration(section.Key, memberName);
        }

        return optionsBuilder;
    }
}