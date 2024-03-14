using App.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected AppDbContext _dbContext = null;

        public Repository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity); 
            return entity;
        }

        public async Task<List<T>> AddRangeAsync(List<T> entities)
        {
            await _dbContext.AddRangeAsync(entities);
            return entities;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => { 
                _dbContext.Update(entity);
            });
            return entity;
        }

        public async Task<List<T>> UpdateRangeAsync(List<T> entities)
        {
            return await Task.Run(() => { 
                _dbContext.Update(entities);
                return entities;
            });
        }
        public async Task<IQueryable<T>> GetAllAsync(bool readOnly = false)
        {
            return await Task.Run(() => {
                if (readOnly) _dbContext.Set<T>().AsNoTracking<T>();
                return _dbContext.Set<T>();//.AsQueryable<T>();
            });
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await GetByIdAsync(id);
            _ = _dbContext.Set<T>().Remove(entity);
        }

        public async Task DeleteBatchAsync(Expression<Func<T, bool>> predicate)
        {
            await Task.Run(() => {
                var entities = _dbContext.Set<T>().Where(predicate);
                if (entities != null && entities.Any())
                {
                    _dbContext.RemoveRange(entities);
                }
            });
        }

        public async Task<IQueryable<T>> ExcuteQueryAsync(string sql, bool readOnly = false)
        {
            return await Task.Run(() => {
                IQueryable<T> result = default;
                if (readOnly)
                    result = _dbContext.Set<T>().FromSqlRaw(sql).AsNoTracking();
                else
                    result = _dbContext.Set<T>().FromSqlRaw(sql);

                return result;
            });
        }

        public async Task ExecuteNonQueryAsync(string query)
        {
            await _dbContext.Database.ExecuteSqlRawAsync(query);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task SetDbContext(AppDbContext appDbContext)
        {
            this._dbContext = appDbContext;
        }
    }
}
