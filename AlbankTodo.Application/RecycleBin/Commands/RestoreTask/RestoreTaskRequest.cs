using AlbankTodo.Application.Common;
using MediatR;

namespace AlbankTodo.Application.RecycleBin.Commands.RestoreTask
{
    public class RestoreTaskRequest : IRequest<ResponseModel>
    {
        public int Id { get; set; }
    }
}
