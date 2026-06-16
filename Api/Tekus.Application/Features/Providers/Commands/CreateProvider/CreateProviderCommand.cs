using MediatR;
using Tekus.Application.DTOs.Provider;

namespace Tekus.Application.Features.Providers.Commands.CreateProvider;

public sealed record CreateProviderCommand(
    string Nit,
    string Name,
    string Email,
    string? Website
) : IRequest<ProviderResponseDto>;