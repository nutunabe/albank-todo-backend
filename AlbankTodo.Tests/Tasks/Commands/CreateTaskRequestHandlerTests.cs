﻿using AlbankTodo.Application.Tasks.Commands.CreateTask;
using AlbankTodo.Core.Entities;
using AlbankTodo.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AlbankTodo.Tests.Tasks.Commands
{
    public class CreateTaskRequestHandlerTests : TestRequestBase
    {
        [Fact]
        public async Task CreateTaskRequestHandler_Success()
        {
            // Arrange
            var handler = new CreateTaskRequestHandler(Repository, Mapper, UnitOfWork);
            var taskTitle = "new task name";
            var taskDescription = "new task description";
            var taskDueDate = new DateTime(2023, 12, 31);

            // Act
            var response = await handler.Handle(new CreateTaskRequest
            {
                Title = taskTitle,
                Description = taskDescription,
                DueDate = taskDueDate,
            }, CancellationToken.None);
            var task = response.Result;

            // Assert
            Assert.NotNull(task);
            Assert.Equal(taskTitle, task.Title);
            Assert.Equal(taskDescription, task.Description);
            Assert.Equal(taskDueDate, task.DueDate);
            Assert.Equal(DateTime.Today, task.CreatedOn.Date); // ? ? ?
        }
    }
}
