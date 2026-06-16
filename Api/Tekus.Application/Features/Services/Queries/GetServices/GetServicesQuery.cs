using MediatR;
using Tekus.Application.DTOs.Service;

namespace Tekus.Application.Features.Services.Queries.GetServices;

public sealed record GetServicesQuery()
    : IRequest<IEnumerable<ServiceResponseDto>>;