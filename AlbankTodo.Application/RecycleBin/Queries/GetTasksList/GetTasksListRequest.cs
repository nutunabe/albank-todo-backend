using AlbankTodo.Application.Common;
using MediatR;
using System.Collections.Generic;

namespace AlbankTodo.Application.RecycleBin.Queries.GetTasksList
{
    public class GetTasksListRequest : IRequest<IEnumerable<TaskDto>>
    { }
}
