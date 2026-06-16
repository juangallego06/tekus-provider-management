using Microsoft.EntityFrameworkCore;
using Tekus.Domain.Entities;

namespace Tekus.Infrastructure.Persistence;

public class TekusDbContext : DbContext
{
    public TekusDbContext(DbContextOptions<TekusDbContext> options)
        : base(options)
    {
    }

    public DbSet<Provider> Providers => Set<Provider>();

    public DbSet<Service> Services => Set<Service>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(TekusDbContext).Assembly
        );

        base.OnModelCreating(modelBuilder);
    }
}