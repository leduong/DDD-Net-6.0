// App.Infrastructure/Persistence/Repositories/ITaskRepository.cs
using System.Collections.Generic;
using App.Domain.Entities;
using Task = App.Domain.Entities.Task;

namespace App.Infrastructure.Persistence.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAll(string filter = null, string orderBy = null, int? page = null, int? pageSize = null);
        Task GetById(int id);
        void Add(Task task);
        void Update(Task task);
        void Delete(Task task);
        void SaveChanges();
    }
}
