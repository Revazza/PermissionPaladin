namespace PermissionPaladin.Persistance.Services.Interfaces;

/// <summary>
/// Defines the interface for the Unit of Work pattern to manage database transactions.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Asynchronously saves changes to the underlying database
    /// </summary>
    /// <param name="cancellationToken">The cancellation token for the asynchronous operation</param>
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
