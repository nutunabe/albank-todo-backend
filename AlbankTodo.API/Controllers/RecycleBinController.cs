using AlbankTodo.Application.Common;
using AlbankTodo.Application.RecycleBin.Commands.DeleteTask;
using AlbankTodo.Application.RecycleBin.Commands.EmptyRecycleBin;
using AlbankTodo.Application.RecycleBin.Commands.RestoreAllTasks;
using AlbankTodo.Application.RecycleBin.Commands.RestoreTask;
using AlbankTodo.Application.RecycleBin.Queries.GetTask;
using AlbankTodo.Application.RecycleBin.Queries.GetTasksList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlbankTodo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecycleBinController : Controller
    {
        private readonly IMediator _mediator;

        public RecycleBinController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("{id}")]
        public async Task<ResponseModel> Delete(int id)
        {
            var request = new DeleteTaskRequest
            {
                Id = id,
            };
            return await _mediator.Send(request);
        }

        [HttpDelete()]
        public async Task<ResponseModel> DeleteAll()
        {
            return await _mediator.Send(new EmptyRecycleBinRequest());
        }

        [HttpPut("restore/{id}")]
        public async Task<ResponseModel<TaskDto>> Restore(int id)
        {
            var request = new RestoreTaskRequest
            {
                Id = id,
            };
            return await _mediator.Send(request);
        }

        [HttpPut("restore")]
        public async Task<ResponseModel> RestoreAll()
        {
            return await _mediator.Send(new RestoreAllTasksRequest());
        }

        [HttpGet("{id}")]
        public async Task<ResponseModel<TaskDto>> Get(int id)
        {
            var request = new GetTaskRequest
            {
                Id = id,
            };
            return await _mediator.Send(request);
        }

        [HttpGet]
        public async Task<IEnumerable<TaskDto>> GetAll()
        {
            return await _mediator.Send(new GetTasksListRequest());
        }
    }
}
