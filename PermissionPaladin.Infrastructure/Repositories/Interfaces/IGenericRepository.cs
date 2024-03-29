﻿using Microsoft.EntityFrameworkCore.Storage;

namespace PermissionPaladin.Infrastructure.Repositories.Interfaces;

public interface IGenericRepository<T, TId>
    where T : class
{
    Task<T?> AddAsync(T entity);
    IQueryable<T> AsQuery();
    Task<T?> GetByIdAsync(TId id);
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitTransactionAsync(IDbContextTransaction transaction);
    Task RollBackAsync(IDbContextTransaction transaction);
    void Update(T entity);
    void UpdateRange(List<T> entities);
    void Delete(T entity);
    void SetEntityStateToModified(T entity);
    Task SaveChangesAsync();
}
