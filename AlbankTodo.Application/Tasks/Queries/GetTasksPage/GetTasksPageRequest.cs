using AlbankTodo.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbankTodo.Application.Tasks.Queries.GetTasksPage
{
    public class GetTasksPageRequest : IRequest<PageModel<TaskDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
