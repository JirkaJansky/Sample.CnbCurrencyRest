﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.CnbCurrencyRest.API.Dtos;
using Sample.CnbCurrencyRest.API.Dtos.Errors;
using Sample.CnbCurrencyRest.API.Dtos.QueryParams;
using Sample.CnbCurrencyRest.Application.Features.Currency.Queries;

namespace Sample.CnbCurrencyRest.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ExchangeRateController : Controller
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public ExchangeRateController(ISender mediator, IMapper mapper, ILogger<ExchangeRateController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>List paginated filtered Exchanges</summary>
    /// <remarks>List paginated Exchanges based on given filter</remarks>
    [HttpPost(nameof(ListExchangeRateCurrencies) ,Name = nameof(ListExchangeRateCurrencies))]
    [ProducesResponseType(typeof(PaginatedListDto<ExchangeRateDataDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> ListExchangeRateCurrencies([FromBody] ListFilteredExchangeRateDto queryParams, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Controller {ControllerName} call {method} with {@queryParams}", nameof(ExchangeRateController), nameof(ListExchangeRateCurrencies), queryParams);

        var listCurrency = await _mediator
            .Send(_mapper.Map<ListFilteredExchangeRateQuery>(queryParams), cancellationToken);

        return Ok(_mapper.Map<PaginatedListDto<ExchangeRateDataDto>>(listCurrency));
    }
}