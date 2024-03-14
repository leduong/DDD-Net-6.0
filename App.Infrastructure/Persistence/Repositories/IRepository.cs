using App.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Persistence.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<List<T>> AddRangeAsync(List<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<List<T>> UpdateRangeAsync(List<T> entities);
        Task<T> GetByIdAsync(object id);
        Task<IQueryable<T>> GetAllAsync(bool readOnly = false);
        Task<IQueryable<T>> ExcuteQueryAsync(string sql, bool readOnly = false);
        Task ExecuteNonQueryAsync(string query);
        Task DeleteAsync(object id);
        Task DeleteBatchAsync(Expression<Func<T, bool>> predicate);
        Task SetDbContext(AppDbContext appDbContext);
        Task SaveChangesAsync();
    }
}
