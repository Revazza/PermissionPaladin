using PermissionPaladin.Infrastructure.Services.Interfaces;
using PermissionPaladin.Persistance.Context;

namespace PermissionPaladin.Infrastructure.Services;

/// <summary>
/// Implementation of the Unit of Work pattern for handling database transactions
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly PermissionPaladinDbContext _context;

    /// <summary>
    /// Initializes a new instance of the UnitOfWork class
    /// </summary>
    /// <param name="context">The database context used for unit of work operations</param>
    public UnitOfWork(PermissionPaladinDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Asynchronously saves changes to the underlying database
    /// </summary>
    /// <param name="cancellationToken">The cancellation token for the asynchronous operation</param>
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
