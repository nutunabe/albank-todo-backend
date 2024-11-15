﻿using AlbankTodo.Application.Common;
using AlbankTodo.Core.Entities;
using AlbankTodo.Core.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AlbankTodo.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskRequestHandler : IRequestHandler<UpdateTaskRequest, ResponseModel<TaskDto>>
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

        public async Task<ResponseModel<TaskDto>> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskAsync(request.Id);
            if (task == null)
            {
                throw new AlbankTodoException(HttpStatusCode.NotFound, $"Task with Id {request.Id} not found.");
            }
            _mapper.Map(request, task);
            if (task.Status == Status.Completed)
            {
                task.CompletedOn = DateTime.Now;
            }
            _taskRepository.UpdateTask(task);
            await _unitOfWork.Complete();
            var result = _mapper.Map<TaskDto>(task);
            return new ResponseModel<TaskDto>(result);
        }
    }
}
