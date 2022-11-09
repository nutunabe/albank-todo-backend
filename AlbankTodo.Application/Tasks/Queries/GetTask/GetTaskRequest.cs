using AlbankTodo.Application.Common;
using MediatR;

namespace AlbankTodo.Application.Tasks.Queries.GetTask
{
    public class GetTaskRequest : IRequest<ResponseModel<TaskDto>>
    {
        public int Id { get; set; }
    }
}
