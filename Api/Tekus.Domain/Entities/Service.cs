namespace Tekus.Domain.Entities;

public sealed class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal HourlyRate { get; set; }

    public int ProviderId { get; set; }

    public Provider Provider { get; set; } = null!;
}