namespace Tekus.Application.DTOs.Provider
{
    public sealed record ProviderResponseDto(
        int Id,
        string Nit,
        string Name,
        string Email,
        string? Website
    );
}
