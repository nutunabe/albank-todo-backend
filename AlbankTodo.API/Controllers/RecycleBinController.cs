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
        public async Task<ActionResult<TaskDto>> Delete(int id)
        {
            var request = new DeleteTaskRequest
            {
                Id = id,
            };
            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpDelete()]
        public async Task<ActionResult<TaskDto>> DeleteAll()
        {
            var res = await _mediator.Send(new EmptyRecycleBinRequest());
            return Ok(res);
        }

        [HttpPut("restore/{id}")]
        public async Task<ActionResult<TaskDto>> Restore(int id)
        {
            var request = new RestoreTaskRequest
            {
                Id = id,
            };
            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpPut("restore")]
        public async Task<ActionResult<TaskDto>> RestoreAll()
        {
            var res = await _mediator.Send(new RestoreAllTasksRequest());
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> Get(int id)
        {
            var request = new GetTaskRequest
            {
                Id = id,
            };
            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetAll()
        {
            var res = await _mediator.Send(new GetTasksListRequest());
            return Ok(res);
        }
    }
}
