using MediatR;
using System.Collections.Generic;

namespace AlbankTodo.Application.Tasks.Queries.GetTasksList
{
    public class GetTasksListRequest : IRequest<IEnumerable<TaskDto>>
    { }
}
