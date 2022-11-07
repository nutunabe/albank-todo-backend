using AlbankTodo.Application.Common;
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

namespace AlbankTodo.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskRequestHandler : IRequestHandler<UpdateTaskRequest>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public UpdateTaskRequestHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskAsync(request.Id);
            if (task == null)
            {
                throw new AlbankTodoException("NOT_FOUND", $"Task with Id {request.Id} not found.");
            }
            _mapper.Map(request, task);
            _taskRepository.UpdateTask(task);
            // TODO: saveChangesAsync();
            return new Unit();
        }
    }
}
