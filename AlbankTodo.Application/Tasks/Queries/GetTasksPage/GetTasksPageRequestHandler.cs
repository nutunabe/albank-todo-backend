using AlbankTodo.Application.Common;
using AlbankTodo.Core.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            var pageSize = request.PageSize <= 0 ? 10 : request.PageSize;
            var (items, count) = await _taskRepository.GetTasksPageAsync(pageNumber - 1, pageSize);
            var pageItems = _mapper.Map<IEnumerable<TaskDto>>(items);
            var page = new PageModel<TaskDto>(pageItems, pageNumber, pageSize, count);
            return page;
        }
    }
}
