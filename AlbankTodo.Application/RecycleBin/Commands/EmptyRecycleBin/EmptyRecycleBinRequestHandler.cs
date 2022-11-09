using AlbankTodo.Application.Common;
using AlbankTodo.Core.Interfaces;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AlbankTodo.Application.RecycleBin.Commands.EmptyRecycleBin
{
    public class EmptyRecycleBinRequestHandler : IRequestHandler<EmptyRecycleBinRequest, ResponseModel>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmptyRecycleBinRequestHandler(ITaskRepository taskRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseModel> Handle(EmptyRecycleBinRequest request, CancellationToken cancellationToken)
        {
            _taskRepository.DeleteAllRecycledTasks();
            await _unitOfWork.Complete();
            return new ResponseModel();
        }
    }
}
