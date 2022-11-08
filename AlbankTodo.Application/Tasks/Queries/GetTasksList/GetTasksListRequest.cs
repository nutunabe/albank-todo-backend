using AlbankTodo.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbankTodo.Application.Tasks.Queries.GetTasksList
{
    public class GetTasksListRequest : IRequest<IEnumerable<TaskDto>>
    { }
}
