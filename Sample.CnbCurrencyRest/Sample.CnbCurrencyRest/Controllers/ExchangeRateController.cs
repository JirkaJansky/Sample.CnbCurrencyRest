using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.CnbCurrencyRest.API.Dtos;
using Sample.CnbCurrencyRest.API.Dtos.QueryParams;
using Sample.CnbCurrencyRest.Application.Features.Currency.Queries;

namespace Sample.CnbCurrencyRest.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ExchangeRateController : Controller
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public ExchangeRateController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>List paginated filtered Devices</summary>
    /// <remarks>List paginated Devices based on given filter</remarks>
    [HttpGet(Name = nameof(ListExchangeRateCurrencies))]
    [ProducesResponseType(typeof(ICollection<ExchangeRateDataDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListExchangeRateCurrencies([FromQuery] ListFilteredExchangeRateDto queryParams, CancellationToken cancellationToken)
    {
        var listCurrency = await _mediator
            .Send(new ListFilteredExchangeRateQuery { CurrencyTableDate = queryParams.CurrencyTableDate }, cancellationToken);

        return Ok(_mapper.Map<ICollection<ExchangeRateDataDto>>(listCurrency));
    }
}