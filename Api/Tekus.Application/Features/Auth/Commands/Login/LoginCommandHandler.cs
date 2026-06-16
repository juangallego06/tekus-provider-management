using MediatR;
using Tekus.Application.Common.Exceptions;
using Tekus.Application.DTOs.Auth;
using Tekus.Application.Interfaces.Services;

namespace Tekus.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler
    : IRequestHandler<LoginCommand, LoginResponseDto>
{
    private readonly IJwtService _jwtService;

    public LoginCommandHandler(
        IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    public async Task<LoginResponseDto> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        const string username = "admin";
        const string password = "Tekus2025*";

        if (
            request.Username != username ||
            request.Password != password)
        {
            throw new InvalidCredentialsException(
                "Invalid credentials.");
        }

        var token =
            _jwtService.GenerateToken(request.Username);

        return await Task.FromResult(
            new LoginResponseDto(
                token,
                DateTime.UtcNow.AddHours(1)
            )
        );
    }
}