using AlbankTodo.Application.Tasks.Queries;
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
            var result = await handler.Handle(
                new GetTaskRequest
                {
                    Id = 1,
                }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<TaskDto>();
            result.Id.ShouldBe(1);
            result.Title.ShouldBe("Title 1");
            result.Description.ShouldBe("Description 1");
            result.DueDate.ShouldBe(new DateTime(2022, 11, 10));
            result.CreatedOn.ShouldBe(DateTime.Today);
            result.CompletedOn.ShouldBeNull();
            result.Status.ShouldBe(Status.CREATED);
        }
    }
}
