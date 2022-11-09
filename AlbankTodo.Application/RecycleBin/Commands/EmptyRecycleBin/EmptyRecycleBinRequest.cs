using AlbankTodo.Application.Common;
using MediatR;

namespace AlbankTodo.Application.RecycleBin.Commands.EmptyRecycleBin
{
    public class EmptyRecycleBinRequest : IRequest<ResponseModel>
    { }
}
