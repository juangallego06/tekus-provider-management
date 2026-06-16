using Tekus.Domain.Entities;

namespace Tekus.Application.Interfaces.Persistence
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllAsync();

        Task<Service?> GetByIdAsync(int id);

        Task<Service> AddAsync(Service service);

        Task<int> CountAsync();

        Task<decimal> AverageHourlyRateAsync();
    }
}
