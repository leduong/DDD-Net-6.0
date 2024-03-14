using App.Domain.Entities.Common;
using App.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<Type, object> repositories;

        public UnitOfWork(AppDbContext context, IServiceProvider serviceProvider)
        {
            this._dbContext = context;
            this._serviceProvider = serviceProvider;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            /*
            if (repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)repositories[typeof(T)];
            }

            var repositoryType = typeof(Repository<>).MakeGenericType(typeof(T));
            var repository = (IRepository<T>)Activator.CreateInstance(repositoryType, _dbContext);
            repositories.Add(typeof(T), repository);
            return repository;
            */
            var service = _serviceProvider.GetRequiredService<IRepository<T>>();
            service.SetDbContext(this._dbContext);
            return service;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
