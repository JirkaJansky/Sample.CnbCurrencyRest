using System.Text;

namespace Sample.CnbCurrencyRest.Domain.Common.Helpers;

public static class ConfigurationValidator
{
    private static readonly List<Tuple<string, string>> MissingConfigurations = new();

    public static void AddMissingConfiguration(string key, string value) => MissingConfigurations.Add(Tuple.Create(key, value));

    public static void EnsureIsValid()
    {
        if (!MissingConfigurations.Any())
            return;

        StringBuilder stringBuilder = new("CONFIGURATION ERRORS!");
        stringBuilder.AppendLine().AppendLine("Missing configuration value for:");

        foreach (var item in MissingConfigurations)
        {
            stringBuilder.AppendLine($" - {item.Item1}: {item.Item2}");
        }
        stringBuilder.AppendLine();

        throw new Exception(stringBuilder.ToString());
    }
}