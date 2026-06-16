namespace Tekus.Application.Interfaces.Services;

public interface IEmailService
{
    Task SendServiceCreatedAsync(string providerEmail, string providerName, string serviceName);
}