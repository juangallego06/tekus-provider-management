using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tekus.Application.DTOs.Auth;
using Tekus.Application.Features.Auth.Commands.Login;

namespace Tekus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody]
        LoginRequestDto request)
    {
        var response =
            await _mediator.Send(
                new LoginCommand(
                    request.Username,
                    request.Password
                ));

        return Ok(response);
    }
}