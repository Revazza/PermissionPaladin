using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using PermissionPaladin.Persistance.Context;

namespace PermissionPaladin.Persistance.Repositories;

public class GenericRepository<T, TId>
    : IGenericRepository<T, TId>
    where T : class
{
    protected readonly PermissionPaladinDbContext _context;
    private readonly DbSet<T> _entities;

    public GenericRepository(PermissionPaladinDbContext context)
    {
        _context = context;
        _entities = _context.Set<T>();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        await transaction.CommitAsync();
    }

    public async Task RollBackAsync(IDbContextTransaction transaction)
    {
        await transaction.RollbackAsync();
    }

    public async Task<T?> AddAsync(T entity)
    {
        return (await _entities.AddAsync(entity)).Entity;
    }

    public virtual void Delete(T entity)
    {
        _entities.Remove(entity);
    }

    public IQueryable<T> AsQuery()
    {
        return _entities.AsQueryable();
    }

    public virtual async Task<T?> GetByIdAsync(TId id)
    {
        return await _entities.FindAsync(id);
    }

    public virtual void Update(T entity)
    {
        _context.Update(entity);
    }

    public virtual void UpdateRange(List<T> entities)
    {
        _context.UpdateRange(entities);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void SetEntityStateToModified(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }
}

