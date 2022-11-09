using AlbankTodo.Application.Common;
using MediatR;

namespace AlbankTodo.Application.RecycleBin.Commands.RestoreTask
{
    public class RestoreTaskRequest : IRequest<ResponseModel<TaskDto>>
    {
        public int Id { get; set; }
    }
}
