using AlbankTodo.Application.Common;
using AlbankTodo.Core.Interfaces;
using AlbankTodo.Infrastructure.Data;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlbankTodo.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskRequestHandler : IRequestHandler<DeleteTaskRequest, ResponseModel>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTaskRequestHandler(ITaskRepository taskRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseModel> Handle(DeleteTaskRequest request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskAsync(request.Id);
            if (task == null)
            {
                throw new AlbankTodoException(HttpStatusCode.NotFound, $"Task with Id {request.Id} not found.");
            }
            _taskRepository.DeleteTask(task);
            await _unitOfWork.Complete();
            var response =  new ResponseModel
            {
                Result = "success",
            };
            return response;
        }
    }
}
