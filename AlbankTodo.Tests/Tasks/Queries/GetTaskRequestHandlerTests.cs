using AlbankTodo.Application.Common;
using AlbankTodo.Application.Tasks.Queries.GetTask;
using AlbankTodo.Core.Entities;
using AlbankTodo.Tests.Common;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AlbankTodo.Tests.Tasks.Queries
{
    public class GetTaskRequestHandlerTests : TestRequestBase
    {
        [Fact]
        public async Task GetTaskRequestHandler_Success()
        {
            // Arrange
            var handler = new GetTaskRequestHandler(Repository, Mapper);

            // Act
            var response = await handler.Handle(
                new GetTaskRequest
                {
                    Id = 1,
                }, CancellationToken.None);
            var task = response.Result;

            // Assert
            task.ShouldBeOfType<TaskDto>();
            task.Id.ShouldBe(1);
            task.Title.ShouldBe("Title 1");
            task.Description.ShouldBe("Description 1");
            task.DueDate.ShouldBe(new DateTime(2022, 11, 10));
            task.CreatedOn.ShouldBe(DateTime.Today);
            task.CompletedOn.ShouldBeNull();
            task.Status.ShouldBe(Status.Created);
        }
    }
}
