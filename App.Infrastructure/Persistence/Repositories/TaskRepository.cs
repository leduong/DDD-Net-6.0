using System;
using System.Collections.Generic;
using System.Linq;
using App.Domain.Entities;
using Task = App.Domain.Entities.Task;

namespace App.Infrastructure.Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Task> GetAll(string filter = null, string orderBy = null, int? page = null, int? pageSize = null)
        {
            IQueryable<Task> query = _context.Task;

            // Filtering
            if (!string.IsNullOrWhiteSpace(filter))
            {
                query = query.Where(t => t.Title.Contains(filter));
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "title":
                        query = query.OrderBy(t => t.Title);
                        break;
                    // Add more sorting options if needed
                    default:
                        // Default sorting by Id
                        query = query.OrderBy(t => t.Id);
                        break;
                }
            }

            // Pagination
            if (page.HasValue && pageSize.HasValue)
            {
                int skip = (page.Value - 1) * pageSize.Value;
                query = query.Skip(skip).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public Task GetById(int id)
        {
            return _context.Task.FirstOrDefault(t => t.Id == id);
        }

        public void Add(Task task)
        {
            _context.Task.Add(task);
        }

        public void Update(Task task)
        {
            _context.Task.Update(task);
        }

        public void Delete(Task task)
        {
            _context.Task.Remove(task);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
