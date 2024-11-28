using System.ComponentModel.DataAnnotations;

namespace Sample.CnbCurrencyRest.API.Options;

public class CnbApiOptions
{
    public const string ConfigurationSection = nameof(CnbApiOptions);

    [Required]
    [Url]
    public string CnbDayCurrencyUri { get; set; } = null!;

    [Required]
    [Range(1, int.MaxValue)]
    public int CSVHeaderLine { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int CSVDataLine { get; set; }

    [Required]
    public string CSVDelimetr { get; set; } = null!;
}