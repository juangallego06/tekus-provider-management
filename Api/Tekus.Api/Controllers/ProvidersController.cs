using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tekus.Application.Features.Providers.Commands.CreateProvider;
using Tekus.Application.Features.Providers.Queries.GetProviders;

[ApiController]
[Route("api/providers")]
public class ProvidersController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProvidersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response =
            await _mediator.Send(new GetProvidersQuery());

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateProviderCommand command)
    {
        var response =
            await _mediator.Send(command);

        return Created("", response);
    }
}