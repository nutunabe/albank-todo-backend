using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using AlbankTodo.Application.Tasks.Queries;
using AlbankTodo.Application.Tasks.Queries.GetTask;
using AlbankTodo.Application.Tasks.Commands.CreateTask;
using AlbankTodo.Application.Tasks.Commands.UpdateTask;
using AlbankTodo.Application.Tasks.Commands.DeleteTask;
using AlbankTodo.Application.Tasks.Queries.GetTasksList;
using System.Collections.Generic;
using AlbankTodo.Application.Common;
using AlbankTodo.Application.Tasks.Queries.GetTasksPage;

namespace AlbankTodo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateTaskRequest request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateTaskRequest request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
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

        [HttpGet("page")]
        public async Task<ActionResult<PageModel<TaskDto>>> GetPage([FromQuery] GetTasksPageRequest request)
        {
            request.PageNumber = request.PageNumber == 0 ? 1 : request.PageNumber;
            request.PageSize = request.PageSize == 0 ? 10 : request.PageSize;
            var res = await _mediator.Send(request);
            return Ok(res);
        }
    }
}
