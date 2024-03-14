// App.ApiService/Controllers/TasksController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using App.Domain.Entities;
using App.Infrastructure.Persistence.Repositories;
using Task = App.Domain.Entities.Task;

namespace App.ApiService.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public IActionResult GetAllTasks(string filter = null, string orderBy = null, int? page = null, int? pageSize = null)
        {
            var tasks = _taskRepository.GetAll(filter, orderBy, page, pageSize);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = _taskRepository.GetById(id);
            if (task == null)
                return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public IActionResult CreateTask(Task task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _taskRepository.Add(task);
            _taskRepository.SaveChanges();

            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, Task task)
        {
            if (id != task.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _taskRepository.Update(task);
            _taskRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _taskRepository.GetById(id);
            if (task == null)
                return NotFound();

            _taskRepository.Delete(task);
            _taskRepository.SaveChanges();

            return NoContent();
        }
    }
}
