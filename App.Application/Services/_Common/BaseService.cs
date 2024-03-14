using App.Domain.Entities.Common;
using App.Infrastructure.Persistence.Repositories;
using App.Shared.Response;
using AutoMapper;
using System.Linq.Expressions;

namespace App.Application.Services.Common
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<ResponseData<T>> AddAsync(T entity)
        {
            var result = await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return new ResponseData<T>
            {
                Success = true,
                Data = result
            };
        }

        public virtual async Task<ResponseData<TResponse>> AddAsync<TRequest, TResponse>(TRequest request) 
                where TResponse : class where TRequest : class
        {
            var entity = _mapper.Map<T>(request);
            var response = await this.AddAsync(entity);
            var result = _mapper.Map<TResponse>(response.Data);
            return new ResponseData<TResponse>
            {
                Success = true,
                Data = result
            };
        }

        public virtual async Task<ResponseData<List<T>>> AddRangeAsync(List<T> entities)
        {
            var result = await _repository.AddRangeAsync(entities);
            return new ResponseData<List<T>>
            {
                Success= true,
                Data= result
            };
        }

        public virtual async Task<ResponseData<List<TResponse>>> AddRangeAsync<TRequest, TResponse>(List<TRequest> requestObjs)
                where TResponse : class where TRequest: class
        {
            var entities = _mapper.Map<List<T>>(requestObjs);
            var response = await this.AddRangeAsync(entities);
            var result = _mapper.Map<List<TResponse>>(response.Data);
            return new ResponseData<List<TResponse>>
            {
                Success = true,
                Data = result
            };
        }

        public virtual async Task<ResponseData<T>> UpdateAsync(T entity)
        {
            var result = await _repository.UpdateAsync(entity);
            return new ResponseData<T>
            {
                Success = true,
                Data = result
            };
        }

        public virtual async Task<ResponseData<TReponse>> UpdateAsync<TRequest, TReponse>(TRequest requestObj)
                where TReponse : class where TRequest : class
        {
            var entity = _mapper.Map<T>(requestObj);
            var response = await this.UpdateAsync(entity);
            var result = _mapper.Map<TReponse>(response.Data);
            return new ResponseData<TReponse>
            {
                Success = true,
                Data = result
            };
        }

        public virtual async Task<ResponseData<List<T>>> UpdateRangeAsync(List<T> entities)
        {
            var result = await _repository.UpdateRangeAsync(entities);
            return new ResponseData<List<T>>
            {
                Success = true,
                Data = result
            };
        }

        public virtual async Task<ResponseData<List<TResponse>>> UpdateRangeAsync<TRequest, TResponse>(List<TRequest> requestObjs)
                where TResponse : class where TRequest: class
        {
            var entities = _mapper.Map<List<T>>(requestObjs);
            var response = await this.UpdateRangeAsync(entities);
            var result = _mapper.Map<List<TResponse>>(response.Data);
            return new ResponseData<List<TResponse>>
            {
                Success = true,
                Data = result
            };
        }

        public virtual async Task DeleteAsync(object id)
        {
            await _repository.DeleteAsync(id);
        }

        public virtual async Task DeleteBatchAsync(Expression<Func<T, bool>> predicate)
        {
            await _repository.DeleteBatchAsync(predicate);
        }

        public virtual async Task<ResponseData<IQueryable<T>>> ExcuteQueryAsync(string sql, bool readOnly = false)
        {
            var result = await _repository.ExcuteQueryAsync(sql, readOnly);
            return new ResponseData<IQueryable<T>>
            {
                Success = true,
                Data = result
            };
        }

        public virtual async Task<ResponseData<IQueryable<TResponse>>> ExcuteQueryAsync<TResponse>(string sql, bool readOnly = false) where TResponse : class
        {
            var response = await this.ExcuteQueryAsync(sql, readOnly);
            var result = _mapper.Map<IQueryable<TResponse>>(response.Data);
            return new ResponseData<IQueryable<TResponse>>
            {
                Success = true,
                Data = result
            };
        }

        public virtual async Task ExecuteNonQueryAsync(string query)
        {
            await _repository.ExecuteNonQueryAsync(query);
        }

        public virtual async Task<ResponseData<IQueryable<T>>> GetAllAsync(bool readOnly = false)
        {
            var result = await _repository.GetAllAsync(readOnly);
            return new ResponseData<IQueryable<T>>
            {
                Success = true,
                Data = result
            };
        }
        public virtual async Task<ResponseData<IQueryable<TResponse>>> GetAllAsync<TResponse>(bool readOnly = false) where TResponse: class
        {
            var response = await this.GetAllAsync(readOnly);
            var result = _mapper.Map<IQueryable<TResponse>>(response.Data);
            return new ResponseData<IQueryable<TResponse>>
            {
                Success = true,
                Data = result
            };
        }


        public virtual async Task<ResponseData<T>> GetByIdAsync(object id)
        {
            var result = await _repository.GetByIdAsync(id);
            return new ResponseData<T>
            {
                Success = true,
                Data = result
            };
        }

        public virtual async Task<ResponseData<TResponse>> GetByIdAsync<TResponse>(object id) where TResponse : class
        {
           var response = await this.GetByIdAsync(id);
            var result = _mapper.Map<TResponse>(response.Data);
            return new ResponseData<TResponse>
            {
                Success = true,
                Data = result
            };
        }
    }
}