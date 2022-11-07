using AlbankTodo.Application.Tasks.Queries.GetTask;
using AlbankTodo.Core.Entities;
using AlbankTodo.Core.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlbankTodo.Application.Tasks.Queries.GetTasksList
{
    public class GetTasksListRequestHandler : IRequestHandler<GetTasksListRequest, IEnumerable<AlbankTask>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTasksListRequestHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AlbankTask>> Handle(GetTasksListRequest request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAllTasksAsync();
            return _mapper.Map<IEnumerable<AlbankTask>>(tasks);
        }
    }
}