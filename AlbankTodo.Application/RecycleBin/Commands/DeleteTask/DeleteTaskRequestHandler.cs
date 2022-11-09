using AlbankTodo.Application.Common;
using AlbankTodo.Core.Interfaces;
using AutoMapper;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AlbankTodo.Application.RecycleBin.Commands.DeleteTask
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
            var task = await _taskRepository.GetRecycledTaskAsync(request.Id);
            if (task == null)
            {
                throw new AlbankTodoException(HttpStatusCode.NotFound, $"Task with Id {request.Id} not found in recycle bin.");
            }
            task.IsRecycled = false;
            _taskRepository.DeleteTask(task);
            await _unitOfWork.Complete();
            var response = new ResponseModel
            {
                Result = "success",
            };
            return response;
        }
    }
}
