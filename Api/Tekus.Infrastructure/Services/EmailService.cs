using Microsoft.Extensions.Logging;
using Tekus.Application.Interfaces.Services;

namespace Tekus.Infrastructure.Services;

public sealed class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;

    public EmailService(
        ILogger<EmailService> logger)
    {
        _logger = logger;
    }

    public async Task SendServiceCreatedAsync(
        string providerEmail,
        string providerName,
        string serviceName)
    {
        _logger.LogInformation(
            """
            ===== EMAIL SIMULATION =====
            To: {Email}
            Provider: {Provider}
            Subject: New Service Registered
            Body: Your service '{Service}' has been successfully registered.
            ============================
            """,
            providerEmail,
            providerName,
            serviceName);

        await Task.CompletedTask;
    }
}