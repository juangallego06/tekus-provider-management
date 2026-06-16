using Tekus.Domain.Entities;

namespace Tekus.Application.Interfaces.Persistence
{
    public interface IProviderRepository
    {
        Task<IEnumerable<Provider>> GetAllAsync();

        Task<Provider?> GetByIdAsync(int id);

        Task<Provider> AddAsync(Provider provider);

        Task<bool> ExistsByEmailAsync(string email);
    }
}
