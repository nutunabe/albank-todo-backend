using AlbankTodo.Application.Common;
using AlbankTodo.Core.Interfaces;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AlbankTodo.Application.RecycleBin.Commands.RestoreAllTasks
{
    public class RestoreAllTasksRequestHandler : IRequestHandler<RestoreAllTasksRequest, ResponseModel>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RestoreAllTasksRequestHandler(ITaskRepository taskRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseModel> Handle(RestoreAllTasksRequest request, CancellationToken cancellationToken)
        {
            _taskRepository.RestoreAllRecycledTasks();
            await _unitOfWork.Complete();
            return new ResponseModel();
        }
    }
}
