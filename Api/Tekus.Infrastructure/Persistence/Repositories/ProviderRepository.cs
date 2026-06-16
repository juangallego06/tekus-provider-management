using Microsoft.EntityFrameworkCore;
using Tekus.Application.Interfaces.Persistence;
using Tekus.Domain.Entities;

namespace Tekus.Infrastructure.Persistence.Repositories;

public class ProviderRepository : IProviderRepository
{
    private readonly TekusDbContext _context;

    public ProviderRepository(TekusDbContext context)
    {
        _context = context;
    }

    public async Task<Provider> AddAsync(Provider provider)
    {
        await _context.Providers.AddAsync(provider);
        return provider;
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _context.Providers
            .AnyAsync(x => x.Email == email);
    }

    public async Task<IEnumerable<Provider>> GetAllAsync()
    {
        return await _context.Providers
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Provider?> GetByIdAsync(int id)
    {
        return await _context.Providers
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Providers
            .AnyAsync(x => x.Id == id);
    }

    public async Task<int> CountAsync()
    {
        return await _context.Providers.CountAsync();
    }
}