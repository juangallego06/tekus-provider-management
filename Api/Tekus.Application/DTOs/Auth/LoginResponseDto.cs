namespace Tekus.Application.DTOs.Auth
{
    public sealed record LoginResponseDto(
        string Token,
        DateTime ExpiresAt
    );
}
