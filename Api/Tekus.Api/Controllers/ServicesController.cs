using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tekus.Application.Features.Services.Commands.CreateService;
using Tekus.Application.Features.Services.Queries.GetServices;

namespace Tekus.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ServicesController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response =
            await _mediator.Send(
                new GetServicesQuery());

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateServiceCommand command)
    {
        var response =
            await _mediator.Send(command);

        return CreatedAtAction(
            nameof(GetAll),
            response);
    }
}