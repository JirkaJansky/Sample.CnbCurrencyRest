using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Options;
using Sample.CnbCurrencyRest.Domain.Common.Exceptions;
using Sample.CnbCurrencyRest.Domain.Common.Helpers;
using Sample.CnbCurrencyRest.Domain.Common.Interfaces.Services;
using Sample.CnbCurrencyRest.Domain.Common.Options;
using Sample.CnbCurrencyRest.Domain.Models;
using Sample.CnbCurrencyRest.Domain.Models.Filters;
using Sample.CnbCurrencyRest.Infrastructure.Interfaces;
using Sample.CnbCurrencyRest.Infrastructure.Models;
using System.Globalization;
using System.Linq.Expressions;

namespace Sample.CnbCurrencyRest.Infrastructure.Services;

public class CnbExchangeRateService : ICnbExchangeRateService
{
    private readonly ICnbExchangeRateClient _cnbExchangeRateClient;
    private readonly IMapper _mapper;
    private readonly CnbApiOptions _options;

    public CnbExchangeRateService(ICnbExchangeRateClient cnbExchangeRateClient, IOptions<CnbApiOptions> options, IMapper mapper)
    {
        _cnbExchangeRateClient = cnbExchangeRateClient;
        _mapper = mapper;
        _options = options.Value;
    }

    public async Task<ICollection<ExchangeRateDataModel>> GetListExchangeDataForDateAsync(DateTime date, CancellationToken cancellationToken)
    {
        return _mapper
            .Map<ICollection<ExchangeRateDataModel>>(
                await GetExchangeDataForDateAsync(date, cancellationToken)
            );
    }

    public async Task<PaginatedListModel<ExchangeRateDataModel>> GetFilteredCurrencyForDatePageAsync(ExchangeRateDataFilter filter, CancellationToken cancellationToken)
    {
        var exchangeRateDatas =
            (await GetExchangeDataForDateAsync(filter.ExchangeDataFromDate, cancellationToken)).AsQueryable();

        exchangeRateDatas = exchangeRateDatas
            .Where(GetFilterFunc(filter));

        var paginatedData = exchangeRateDatas
            .PaginatedList(filter.PageIndex, filter.PageSize, filter.GetAllInOnePage);

        return _mapper
            .Map<PaginatedListModel<ExchangeRateDataModel>>(
                paginatedData
            );
    }

    private Expression<Func<CsvExchangeRateData, bool>> GetFilterFunc(ExchangeRateDataFilter filter)
    {
        var filterExpression = PredicateBuilder.True<CsvExchangeRateData>();

        if (!string.IsNullOrWhiteSpace(filter.CodeSearch))
        {
            filterExpression = filterExpression.And(data =>
                data.Code.Contains(filter.CodeSearch, StringComparison.InvariantCultureIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(filter.CurrencyNameSearch))
        {
            filterExpression = filterExpression.And(data =>
                data.CurrencyName.Contains(filter.CurrencyNameSearch, StringComparison.InvariantCultureIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(filter.CountryCodeSearch))
        {
            filterExpression = filterExpression.And(data =>
                data.Country.Contains(filter.CountryCodeSearch, StringComparison.InvariantCultureIgnoreCase));
        }

        if (filter.ExchangeRateFrom is not null)
        {
            filterExpression = filterExpression.And(data =>
                data.ExchangeRate >= filter.ExchangeRateFrom);
        }

        if (filter.ExchangeRateTo is not null)
        {
            filterExpression = filterExpression.And(data =>
                data.ExchangeRate <= filter.ExchangeRateTo);
        }


        return filterExpression;
    }


    private async Task<ICollection<CsvExchangeRateData>> GetExchangeDataForDateAsync(DateTime date, CancellationToken cancellationToken)
    {
        var currencies = new List<CsvExchangeRateData>();
        var culture = new CultureInfo(_options.CSVCulture);
        try
        {
            using (var reader =
                   new StreamReader(
                       await _cnbExchangeRateClient.GetCvsCurrencyDataByDateAsync(date, cancellationToken)))
            using (var csv = new CsvReader(reader, new CsvConfiguration(culture)
                   {
                       Delimiter = _options.CSVDelimetr,
                       HasHeaderRecord = true,
                       HeaderValidated = null,
                       MissingFieldFound = null,
                   }))
            {
                for (int i = 1; i < _options.CSVHeaderLine; i++)
                    await reader.ReadLineAsync(cancellationToken);


                await foreach (var currency in csv.GetRecordsAsync<CsvExchangeRateData>(cancellationToken))
                {
                    currencies.Add(currency);
                }


            }
        }
        catch (CnbCurrencyRestBaseException cnbCurrencyRestBaseException)
        {
            throw;
        }
        catch (Exception exception)
        {
            throw new CnbCsvReaderException("Error in csv parser", innerException: exception);
        }
        finally
        {
            ;
        }

        return currencies;
    }
}