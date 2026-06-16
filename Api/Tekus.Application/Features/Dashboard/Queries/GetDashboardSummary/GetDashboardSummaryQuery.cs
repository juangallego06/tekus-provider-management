using MediatR;
using Tekus.Application.DTOs.Dashboard;

namespace Tekus.Application.Features.Dashboard.Queries.GetDashboardSummary
{
    public sealed record GetDashboardSummaryQuery()
        : IRequest<DashboardResponseDto>;
}
