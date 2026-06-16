using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tekus.Application.Interfaces.Persistence;
using Tekus.Application.Interfaces.Services;
using Tekus.Infrastructure.Persistence;
using Tekus.Infrastructure.Persistence.Repositories;
using Tekus.Infrastructure.Services;

namespace Tekus.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<TekusDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString(
                    "DefaultConnection")));

        services.AddScoped<IProviderRepository,
            ProviderRepository>();

        services.AddScoped<IServiceRepository,
            ServiceRepository>();

        services.AddScoped<IUnitOfWork,
            UnitOfWork>();

        services.AddScoped<IJwtService,
            JwtService>();

        services.AddScoped<IEmailService,
            EmailService>();

        return services;
    }
}