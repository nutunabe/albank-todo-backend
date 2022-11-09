using AlbankTodo.Application.Common;
using AlbankTodo.Application.Tasks.Commands.UpdateTask;
using AlbankTodo.Core.Entities;
using AlbankTodo.Tests.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AlbankTodo.Tests.Tasks.Commands
{
    public class UpdateTaskRequestHandlerTests : TestRequestBase
    {
        [Fact]
        public async Task UpdateTaskRequestHandler_Success()
        {
            // Arrange
            var handler = new UpdateTaskRequestHandler(Repository, Mapper, UnitOfWork);
            var taskId = TasksContextFactory.TaskIdForUpdate;
            var taskTitle = "updated task name";
            var taskDescription = "updated task description";
            var taskDueDate = new DateTime(2024, 12, 31);
            var taskStatus = Status.InProgress;

            // Act
            var response = await handler.Handle(new UpdateTaskRequest
            {
                Id = taskId,
                Title = taskTitle,
                Description = taskDescription,
                DueDate = taskDueDate,
                Status = taskStatus,
            }, CancellationToken.None);
            var task = response.Result;

            // Assert
            Assert.NotNull(task);
            Assert.Equal(taskTitle, task.Title);
            Assert.Equal(taskDescription, task.Description);
            Assert.Equal(taskDueDate, task.DueDate);
            Assert.Equal(DateTime.Today, task.CreatedOn);
            Assert.Equal(taskStatus, task.Status);
        }

        [Fact]
        public async Task UpdateTaskRequestHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateTaskRequestHandler(Repository, Mapper, UnitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<AlbankTodoException>(async () =>
            await handler.Handle(
                new UpdateTaskRequest
                {
                    Id = 111
                },
                CancellationToken.None));
        }
    }
}
