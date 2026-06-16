namespace Tekus.Application.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        IProviderRepository Providers { get; }

        IServiceRepository Services { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
