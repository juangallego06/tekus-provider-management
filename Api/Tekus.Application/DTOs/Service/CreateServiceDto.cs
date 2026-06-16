namespace Tekus.Application.DTOs.Service
{
    public sealed record CreateServiceDto(
       string Name,
       decimal HourlyRate,
       int ProviderId
   );
}
