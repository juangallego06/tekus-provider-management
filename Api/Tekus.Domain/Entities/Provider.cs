namespace Tekus.Domain.Entities;

public sealed class Provider
{
    public int Id { get; set; }

    public string Nit { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? Website { get; set; }

    public ICollection<Service> Services { get; set; } = [];
}