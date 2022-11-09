using AlbankTodo.Application.Common;
using AlbankTodo.Application.Tasks.Commands.CreateTask;
using AlbankTodo.Application.Tasks.Commands.DeleteTask;
using AlbankTodo.Application.Tasks.Commands.UpdateTask;
using AlbankTodo.Application.Tasks.Queries.GetTask;
using AlbankTodo.Application.Tasks.Queries.GetTasksList;
using AlbankTodo.Application.Tasks.Queries.GetTasksPage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlbankTodo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseModel<TaskDto>> Create([FromBody] CreateTaskRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<ResponseModel<TaskDto>> Update([FromBody] UpdateTaskRequest request)
        {
            return await _mediator.Send(request);
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
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetAll()
        {
            var res = await _mediator.Send(new GetTasksListRequest());
            return Ok(res);
        }

        [HttpGet("page")]
        public async Task<PageModel<TaskDto>> GetPage([FromQuery] GetTasksPageRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
