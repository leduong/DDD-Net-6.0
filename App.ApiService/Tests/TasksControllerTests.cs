// using NUnit.Framework;
// using App.ApiService.Controllers;
// using App.Domain.Entities;
// using App.Infrastructure.Persistence.Repositories;
// using Microsoft.AspNetCore.Mvc;
// using Moq;
// using System.Collections.Generic;
// using Task = App.Domain.Entities.Task;

// namespace App.ApiService.Tests.Controllers
// {
//   [TestFixture]
//   public class TasksControllerTests
//   {
//     private TasksController _tasksController;
//     private Mock<ITaskRepository> _mockTaskRepository;

//     [SetUp]
//     public void Setup()
//     {
//       _mockTaskRepository = new Mock<ITaskRepository>();
//       _tasksController = new TasksController(_mockTaskRepository.Object);
//     }
//     [Test]
//     public void GetAllTasks_ReturnsOkResult()
//     {
//       // Arrange
//       var tasks = new List<Task> { new Task { Id = 1, Title = "Task 1" }, new Task { Id = 2, Title = "Task 2" } };
//       _mockTaskRepository.Setup(repo => repo.GetAll(null, null, null, null)).Returns(tasks);

//       // Act
//       var result = _tasksController.GetAllTasks() as OkObjectResult;

//       // Assert
//       Assert.NotNull(result);
//       Assert.AreEqual(200, result.StatusCode);
//     }

//     [Test]
//     public void GetTaskById_ExistingId_ReturnsOkResult()
//     {
//       // Arrange
//       var existingTask = new Task { Id = 1, Title = "Task 1" };
//       _mockTaskRepository.Setup(repo => repo.GetById(existingTask.Id)).Returns(existingTask);

//       // Act
//       var result = _tasksController.GetTaskById(existingTask.Id) as OkObjectResult;

//       // Assert
//       Assert.NotNull(result);
//       Assert.AreEqual(200, result.StatusCode);
//     }

//     [Test]
//     public void GetTaskById_NonExistingId_ReturnsNotFoundResult()
//     {
//       // Arrange
//       var nonExistingId = 999;
//       _mockTaskRepository.Setup(repo => repo.GetById(nonExistingId)).Returns((Task)null);

//       // Act
//       var result = _tasksController.GetTaskById(nonExistingId) as NotFoundResult;

//       // Assert
//       Assert.NotNull(result);
//       Assert.AreEqual(404, result.StatusCode);
//     }



//     // Add more tests for other actions...
//   }
// }
