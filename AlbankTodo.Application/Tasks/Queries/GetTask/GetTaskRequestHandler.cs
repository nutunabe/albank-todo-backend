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

namespace AlbankTodo.Application.Tasks.Queries.GetTask
{
    public class GetTaskRequestHandler : IRequestHandler<GetTaskRequest, TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTaskRequestHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(GetTaskRequest request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskAsync(request.Id);
            return _mapper.Map<TaskDto>(task);
        }
    }
}
