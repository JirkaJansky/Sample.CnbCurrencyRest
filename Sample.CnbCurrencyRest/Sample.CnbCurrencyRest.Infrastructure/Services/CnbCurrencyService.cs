using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Options;
using Sample.CnbCurrencyRest.API.Options;
using Sample.CnbCurrencyRest.Domain.Models;
using Sample.CnbCurrencyRest.Infrastructure.Interfaces;
using Sample.CnbCurrencyRest.Infrastructure.Models;
using System.Globalization;

namespace Sample.CnbCurrencyRest.Infrastructure.Services;

public class CnbCurrencyService : ICnbCurrencyService
{
    private readonly ICnbCurrencyClient _cnbCurrencyClient;
    private readonly IMapper _mapper;
    private readonly CnbApiOptions _options;

    public CnbCurrencyService(ICnbCurrencyClient cnbCurrencyClient, IOptions<CnbApiOptions> options, IMapper mapper)
    {
        _cnbCurrencyClient = cnbCurrencyClient;
        _mapper = mapper;
        _options = options.Value;
    }

    public async Task<ICollection<ExchangeRateData>> GetCurrencyForDate(DateTime date, CancellationToken cancellationToken)
    {
        var currencies = new List<CsvExchangeRateData>();

        using (var reader = new StreamReader(await _cnbCurrencyClient.GetCvsCurrencyDataByDate(date)))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = _options.CSVDelimetr,
            HasHeaderRecord = true,
            HeaderValidated = null,
            MissingFieldFound = null
        }))
        {
            for (int i = 1; i < _options.CSVHeaderLine; i++)
                await reader.ReadLineAsync(cancellationToken);

            try
            {
                await foreach (var currency in csv.GetRecordsAsync<CsvExchangeRateData>(cancellationToken))
                {
                    currencies.Add(currency);
                }
            }
            catch (Exception ex)
            {
                //TODO Logging or Exception handling
                Console.WriteLine($"Error reading CSV: {ex.Message}");
            }
        }

        return _mapper.Map<ICollection<ExchangeRateData>>(currencies);
    }
}