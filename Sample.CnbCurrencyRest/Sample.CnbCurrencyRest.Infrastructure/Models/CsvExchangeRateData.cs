using CsvHelper.Configuration.Attributes;

namespace Sample.CnbCurrencyRest.Infrastructure.Models;

public class CsvExchangeRateData
{
    /// <summary>
    /// The country associated with the currency.
    /// </summary>
    [Name("země")]
    public string Country { get; set; }

    /// <summary>
    /// The name of the currency.
    /// </summary>
    [Name("měna")]
    public string CurrencyName { get; set; }

    /// <summary>
    /// The amount or quantity for this currency.
    /// </summary>
    [Name("množství")]
    public int Amount { get; set; }

    /// <summary>
    /// The code of the currency (e.g., USD, EUR).
    /// </summary>
    [Name("kód")]
    public string Code { get; set; }

    /// <summary>
    /// The exchange rate for the currency.
    /// </summary>
    [Name("kurz")]
    public decimal ExchangeRate { get; set; }
}