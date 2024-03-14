using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Entities;
using Task = App.Domain.Entities.Task;


namespace App.Infrastructure.Persistence.DBSeed
{
    public class TaskSeed
    {
        public void Seed(ModelBuilder builder)
        {
            var tasks = new List<Task>();

            var random = new Random();

            for (int i = 1; i <= 100; i++)
            {
                var task = new Task
                {
                    Id = i,
                    Title = $"Task {i}",
                    Description = $"Description for Task {i}",
                    Priority = (Priority)random.Next(0, 3), // Randomly select priority
                    DueDate = DateTime.Now.AddDays(random.Next(1, 30)) // Due date within the next 30 days
                };

                tasks.Add(task);
            }

            builder.Entity<Task>().HasData(tasks);
        }
    }
}
