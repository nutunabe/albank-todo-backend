using AlbankTodo.Application.Common;
using AlbankTodo.Core.Entities;
using AlbankTodo.Core.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlbankTodo.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskRequestHandler : IRequestHandler<CreateTaskRequest, ResponseModel<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTaskRequestHandler(ITaskRepository taskRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseModel<TaskDto>> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<AlbankTask>(request);
            task.CreatedOn = DateTime.Now;
            task.Status = Status.Created;
            _taskRepository.AddTask(task);
            await _unitOfWork.Complete();
            var result = _mapper.Map<TaskDto>(task);
            return new ResponseModel<TaskDto>(result);
        }
    }
}
