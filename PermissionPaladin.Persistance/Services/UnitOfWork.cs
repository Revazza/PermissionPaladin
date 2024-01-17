using PermissionPaladin.Persistance.Context;

namespace PermissionPaladin.Persistance.Services;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class UnitOfWork : IUnitOfWork
{
    private readonly PermissionPaladinDbContext _context;

    public UnitOfWork(PermissionPaladinDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

}
