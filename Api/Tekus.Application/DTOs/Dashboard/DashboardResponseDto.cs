namespace Tekus.Application.DTOs.Dashboard
{
    public sealed record DashboardResponseDto(int Providers, int Services, decimal AverageHourlyRate);
}
