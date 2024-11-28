namespace Sample.CnbCurrencyRest.Domain.Models;

public class ExchangeRateData
{
    /// <summary>
    /// The country associated with the currency.
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// The name of the currency.
    /// </summary>
    public string Currency { get; set; }

    /// <summary>
    /// The amount or quantity for this currency.
    /// </summary>
    public int Amount { get; set; }

    /// <summary>
    /// The code of the currency (e.g., USD, EUR).
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// The exchange rate for the currency.
    /// </summary>
    public decimal ExchangeRate { get; set; }
}