using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TasseiTech.Sample.Core.Domain.Abstractions;
using TasseiTech.Sample.Core.Domain.Entities;
using TasseiTech.Sample.Infrastructure.Sql;

namespace TasseiTech.Sample.Infrastructure.Sql.Implementation;

public class Repository<T>(ApplicationContext context) : IRepository<T>
    where T : BaseEntity
{
    private DbSet<T> entities = context.Set<T>();

    public async Task<T> GetByIdAsync(object id)
    {
        return await entities.FindAsync(id);
    }

    public Task<bool> IsExist(long id)
    {
        return entities.AnyAsync(c => c.Id == id);
    }

    public async Task<IList<T>> GetAllAsync()
    {
        return await entities.ToListAsync();
    }

    public async Task InsertAsync(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        await entities.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task InsertAsync(IList<T> entityList)
    {
        if (entityList == null)
            throw new ArgumentNullException(nameof(entityList));

        await entities.AddRangeAsync(entityList);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        entities.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(IList<T> entityList)
    {
        if (entityList == null)
            throw new ArgumentNullException(nameof(entityList));

        entities.UpdateRange(entityList);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        entities.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(IList<T> entityList)
    {
        if (entityList == null)
            throw new ArgumentNullException(nameof(entityList));

        entities.RemoveRange(entityList);
        await context.SaveChangesAsync();
    }

}