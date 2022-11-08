using AlbankTodo.Application.Common;
using AlbankTodo.Core.Interfaces;
using AlbankTodo.Core.Entities;
using AutoMapper;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace AlbankTodo.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskRequestHandler : IRequestHandler<UpdateTaskRequest, ResponseModel>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTaskRequestHandler(ITaskRepository taskRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseModel> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskAsync(request.Id);
            if (task == null)
            {
                throw new AlbankTodoException(HttpStatusCode.NotFound, $"Task with Id {request.Id} not found.");
            }
            _mapper.Map(request, task);
            if (task.Status == Status.COMPLETED)
            {
                task.CompletedOn = DateTime.Now;
            }
            _taskRepository.UpdateTask(task);
            await _unitOfWork.Complete();
            var response = new ResponseModel
            {
                Result = "success",
            };
            return response;
        }
    }
}
