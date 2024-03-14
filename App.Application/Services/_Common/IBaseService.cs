using App.Domain.Entities.Common;
using App.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services.Common
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<ResponseData<T>> AddAsync(T entity);
        Task<ResponseData<TResponse>> AddAsync<TRequest, TResponse>(TRequest entity) where TResponse: class where TRequest : class;
        Task<ResponseData<List<T>>> AddRangeAsync(List<T> entities);
        Task<ResponseData<List<TResponse>>> AddRangeAsync<TRequest, TResponse>(List<TRequest> entities) where TResponse : class where TRequest : class;
        Task<ResponseData<T>> UpdateAsync(T entity);
        Task<ResponseData<TResponse>> UpdateAsync<TRequest, TResponse>(TRequest entity) where TResponse : class where TRequest : class;
        Task<ResponseData<List<T>>> UpdateRangeAsync(List<T> entities);
        Task<ResponseData<List<TResponse>>> UpdateRangeAsync<TRequest, TResponse>(List<TRequest> entities) where TResponse : class where TRequest : class;
        Task<ResponseData<T>> GetByIdAsync(object id);
        Task<ResponseData<TResponse>> GetByIdAsync<TResponse>(object id) where TResponse : class;
        Task<ResponseData<IQueryable<T>>> GetAllAsync(bool readOnly = false);
        Task<ResponseData<IQueryable<TResponse>>> GetAllAsync<TResponse>(bool readOnly = false) where TResponse : class;
        Task<ResponseData<IQueryable<T>>> ExcuteQueryAsync(string sql, bool readOnly = false);
        Task<ResponseData<IQueryable<TResponse>>> ExcuteQueryAsync<TResponse>(string sql, bool readOnly = false) where TResponse : class;
        Task ExecuteNonQueryAsync(string query);
        Task DeleteAsync(object id);
        Task DeleteBatchAsync(Expression<Func<T, bool>> predicate);
    }
}
