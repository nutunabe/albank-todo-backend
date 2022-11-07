using AlbankTodo.Core.Entities;
using AlbankTodo.Core.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlbankTodo.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskRequestHandler : IRequestHandler<CreateTaskRequest>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public CreateTaskRequestHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<AlbankTask>(request);
            task.CreatedOn = DateTime.Now;
            task.Status = Status.CREATED;
            _taskRepository.AddTask(task);
            // TODO: saveChangesAsync();
            return new Unit();
        }
    }
}
