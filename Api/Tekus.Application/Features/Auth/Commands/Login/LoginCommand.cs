using MediatR;
using Tekus.Application.DTOs.Auth;

namespace Tekus.Application.Features.Auth.Commands.Login;

public sealed record LoginCommand(
    string Username,
    string Password
) : IRequest<LoginResponseDto>;