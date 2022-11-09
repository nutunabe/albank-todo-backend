using AlbankTodo.Application.Common;
using AlbankTodo.Application.Tasks.Commands.DeleteTask;
using AlbankTodo.Tests.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AlbankTodo.Tests.Tasks.Commands
{
    public class DeleteTaskRequestHandlerTests : TestRequestBase
    {
        [Fact]
        public async Task DeleteTaskRequestHandler_Success()
        {
            // Arrange
            var handler = new DeleteTaskRequestHandler(Repository, Mapper, UnitOfWork);

            // Act
            await handler.Handle(new DeleteTaskRequest
            {
                Id = TasksContextFactory.TaskIdForDelete,
            }, CancellationToken.None);

            // Assert
            Assert.Null(await Repository.GetTaskAsync(TasksContextFactory.TaskIdForDelete));
        }

        [Fact]
        public async Task DeleteTaskRequestHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteTaskRequestHandler(Repository, Mapper, UnitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<AlbankTodoException>(async () =>
            await handler.Handle(
                new DeleteTaskRequest
                {
                    Id = 222
                },
                CancellationToken.None));
        }


    }
}
