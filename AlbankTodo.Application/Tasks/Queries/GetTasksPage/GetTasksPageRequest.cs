using AlbankTodo.Application.Common;
using MediatR;

namespace AlbankTodo.Application.Tasks.Queries.GetTasksPage
{
    public class GetTasksPageRequest : IRequest<PageModel<TaskDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
