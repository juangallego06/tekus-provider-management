using Tekus.Application.Interfaces.Persistence;

namespace Tekus.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly TekusDbContext _context;

    public UnitOfWork(
        TekusDbContext context,
        IProviderRepository providers,
        IServiceRepository services)
    {
        _context = context;
        Providers = providers;
        Services = services;
    }

    public IProviderRepository Providers { get; }

    public IServiceRepository Services { get; }

    public async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}