using AlbankTodo.Application.Common;
using AlbankTodo.Core.Interfaces;
using AutoMapper;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AlbankTodo.Application.RecycleBin.Queries.GetTask
{
    public class GetTaskRequestHandler : IRequestHandler<GetTaskRequest, TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTaskRequestHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(GetTaskRequest request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetRecycledTaskAsync(request.Id);
            if (task == null)
            {
                throw new AlbankTodoException(HttpStatusCode.NotFound, $"Task with Id {request.Id} not found in recycle bin.");
            }
            return _mapper.Map<TaskDto>(task);
        }
    }
}
