using System.ComponentModel.DataAnnotations;

namespace Sample.CnbCurrencyRest.Domain.Common.Options;

public class CnbApiOptions
{
    public const string ConfigurationSection = nameof(CnbApiOptions);

    [Required(ErrorMessage = $"{nameof(CnbDayCurrencyUri)} is required.")]
    [Url]
    public string CnbDayCurrencyUri { get; set; } = null!;

    [Required(ErrorMessage = $"{nameof(CSVHeaderLine)} is required.")]
    [Range(1, int.MaxValue)]
    public int CSVHeaderLine { get; set; }

    [Required(ErrorMessage = "CSVDelimetr is required.")]
    [MaxLength(1, ErrorMessage = "CSVDelimetr must be a single character.")]
    public string CSVDelimetr { get; set; } = null!;

    [Required(ErrorMessage = $"{nameof(CSVCulture)} is required.")]
    [RegularExpression(@"^[a-z]{2}-[A-Z]{2}$|^InvariantCulture$",
        ErrorMessage = $"{nameof(CSVCulture)} must be in the format 'xx-XX' (e.g., 'en-US', 'cs-CZ') or 'InvariantCulture'.")]
    public string CSVCulture { get; set; } = null!;
}
