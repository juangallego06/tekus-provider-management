namespace Tekus.Application.DTOs.Service
{
    public sealed record ServiceResponseDto(
      int Id,
      string Name,
      decimal HourlyRate,
      int ProviderId,
      string ProviderName
  );
}
