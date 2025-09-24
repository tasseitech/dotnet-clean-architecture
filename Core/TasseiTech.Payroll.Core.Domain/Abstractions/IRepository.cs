using System.Collections.Generic;
using System.Threading.Tasks;
using TasseiTech.Sample.Core.Domain.Entities;

namespace TasseiTech.Sample.Core.Domain.Abstractions;
public interface IRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(object id);
    Task<IList<T>> GetAllAsync();
    Task<bool> IsExist(long id);
    Task InsertAsync(T entity);
    Task InsertAsync(IList<T> entityList);
    Task UpdateAsync(T entity);
    Task UpdateAsync(IList<T> entityList);
    Task DeleteAsync(T entity);
    Task DeleteAsync(IList<T> entityList);
}
