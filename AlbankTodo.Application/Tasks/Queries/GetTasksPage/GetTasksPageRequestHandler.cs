using AlbankTodo.Application.Common;
using AlbankTodo.Core.Interfaces;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AlbankTodo.Application.Tasks.Queries.GetTasksPage
{
    public class GetTasksPageRequestHandler : IRequestHandler<GetTasksPageRequest, PageModel<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTasksPageRequestHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<PageModel<TaskDto>> Handle(GetTasksPageRequest request, CancellationToken cancellationToken)
        {
            var (items, count) = await _taskRepository.GetTasksPageAsync(request.PageNumber, request.PageSize);
            var pageItems = _mapper.Map<IEnumerable<TaskDto>>(items);
            var page = new PageModel<TaskDto>(pageItems, request.PageNumber, request.PageSize, count);
            return page;
        }
    }
}
