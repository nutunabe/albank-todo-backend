using AlbankTodo.Application.Common;
using MediatR;

namespace AlbankTodo.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskRequest : IRequest<ResponseModel>
    {
        public int Id { get; set; }
    }
}
