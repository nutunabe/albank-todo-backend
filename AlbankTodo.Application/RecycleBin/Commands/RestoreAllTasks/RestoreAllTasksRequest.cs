using AlbankTodo.Application.Common;
using MediatR;

namespace AlbankTodo.Application.RecycleBin.Commands.RestoreAllTasks
{
    public class RestoreAllTasksRequest : IRequest<ResponseModel>
    { }
}
