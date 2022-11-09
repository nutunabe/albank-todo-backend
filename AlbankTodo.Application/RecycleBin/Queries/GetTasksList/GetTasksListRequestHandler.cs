using AlbankTodo.Application.Common;
using AlbankTodo.Application.RecycleBin.Queries.GetTasksList;
using AlbankTodo.Core.Interfaces;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AlbankTodo.Application.RecycleBin.Queries.GetRecycledTasksList
{
    public class GetTasksListRequestHandler : IRequestHandler<GetTasksListRequest, IEnumerable<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTasksListRequestHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskDto>> Handle(GetTasksListRequest request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAllRecycledTasksAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }
    }
}
