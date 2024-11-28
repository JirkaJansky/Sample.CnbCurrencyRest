using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.CnbCurrencyRest.API.Dtos;
using Sample.CnbCurrencyRest.API.Dtos.QueryParams;
namespace Sample.CnbCurrencyRest.API.Controllers;

public class CurrencyController : Controller
{

    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public CurrencyController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>List paginated filtered Devices</summary>
    /// <remarks>List paginated Devices based on given filter</remarks>
    [HttpGet(Name = nameof(ListCurrency))]
    public async Task<IActionResult> ListCurrency([FromQuery] ListFilteredCurrencyDto queryParams, CancellationToken cancellationToken)
    {

        return Ok(new List<CurrencyDto>(){});
    }
}
