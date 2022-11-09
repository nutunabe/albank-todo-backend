using AlbankTodo.Application.Common;
using MediatR;

namespace AlbankTodo.Application.RecycleBin.Commands.DeleteTask
{
    public class DeleteTaskRequest : IRequest<ResponseModel>
    {
        public int Id { get; set; }
    }
}
