using MediatR;
using Tekus.Application.DTOs.Provider;

namespace Tekus.Application.Features.Providers.Queries.GetProviders;

public sealed record GetProvidersQuery()
    : IRequest<IEnumerable<ProviderResponseDto>>;