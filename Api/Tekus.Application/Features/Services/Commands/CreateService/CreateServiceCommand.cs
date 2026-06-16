using MediatR;
using Tekus.Application.DTOs.Service;

namespace Tekus.Application.Features.Services.Commands.CreateService;

public sealed record CreateServiceCommand(
    string Name,
    decimal HourlyRate,
    int ProviderId
) : IRequest<ServiceResponseDto>;