using Microsoft.EntityFrameworkCore;
using Tekus.Application.Interfaces.Persistence;
using Tekus.Domain.Entities;

namespace Tekus.Infrastructure.Persistence.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly TekusDbContext _context;

    public ServiceRepository(TekusDbContext context)
    {
        _context = context;
    }

    public async Task<Service> AddAsync(Service service)
    {
        await _context.Services.AddAsync(service);
        return service;
    }

    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        return await _context.Services
            .Include(x => x.Provider)
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Service?> GetByIdAsync(int id)
    {
        return await _context.Services
            .Include(x => x.Provider)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}