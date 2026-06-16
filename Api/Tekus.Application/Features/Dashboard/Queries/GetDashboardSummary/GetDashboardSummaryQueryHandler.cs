using MediatR;
using Tekus.Application.DTOs.Dashboard;
using Tekus.Application.Interfaces.Persistence;

namespace Tekus.Application.Features.Dashboard.Queries.GetDashboardSummary;

public sealed class GetDashboardSummaryQueryHandler
    : IRequestHandler<GetDashboardSummaryQuery, DashboardResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDashboardSummaryQueryHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DashboardResponseDto> Handle(
        GetDashboardSummaryQuery request,
        CancellationToken cancellationToken)
    {
        var providersCount =
            await _unitOfWork.Providers.CountAsync();

        var servicesCount =
            await _unitOfWork.Services.CountAsync();

        var averageHourlyRate =
            await _unitOfWork.Services.AverageHourlyRateAsync();

        return new DashboardResponseDto(
            providersCount,
            servicesCount,
            averageHourlyRate
        );
    }
}