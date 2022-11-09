using AlbankTodo.Application.Common;
using AlbankTodo.Application.Tasks.Queries.GetTasksList;
using AlbankTodo.Tests.Common;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AlbankTodo.Tests.Tasks.Queries
{
    public class GetTasksListRequestHandlerTests : TestRequestBase
    {
        [Fact]
        public async Task GetTasksListRequestHandler_Success()
        {
            // Arrange
            var handler = new GetTasksListRequestHandler(Repository, Mapper);

            // Act
            var result = await handler.Handle(new GetTasksListRequest(), CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<TaskDto>>();
            result.Count().ShouldBe(4);
        }
    }
}
