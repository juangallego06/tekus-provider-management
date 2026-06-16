namespace Tekus.Application.DTOs.Provider
{
    public sealed record CreateProviderDto(
        string Nit,
        string Name,
        string Email,
        string? Website
    );
}
