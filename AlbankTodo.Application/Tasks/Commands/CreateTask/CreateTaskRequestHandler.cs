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
    public class CreateTaskRequestHandler : IRequestHandler<CreateTaskRequest, ResponseModel>
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

        public async Task<ResponseModel> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<AlbankTask>(request);
            task.CreatedOn = DateTime.Now;
            task.Status = Status.CREATED;
            _taskRepository.AddTask(task);
            await _unitOfWork.Complete();
            var response = new ResponseModel
            {
                Result = "success",
            };
            return response;
        }
    }
}
