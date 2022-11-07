﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using AlbankTodo.Application.Tasks.Queries;
using AlbankTodo.Application.Tasks.Queries.GetTask;
using AlbankTodo.API.Dtos;
using AlbankTodo.Application.Tasks.Commands.CreateTask;
using AlbankTodo.Application.Tasks.Commands.UpdateTask;
using AlbankTodo.Application.Tasks.Commands.DeleteTask;
using AlbankTodo.Application.Tasks.Queries.GetTasksList;
using System.Collections.Generic;

namespace AlbankTodo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private readonly IMapper _mapper;

        public TaskController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateTaskDto createTaskDto)
        {
            var command = _mapper.Map<CreateTaskRequest>(createTaskDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateTaskDto updateTaskDto)
        {
            var command = _mapper.Map<UpdateTaskRequest>(updateTaskDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskDto>> Delete(int id)
        {
            var command = new DeleteTaskRequest
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> Get(int id)
        {
            var query = new GetTaskRequest
            {
                Id = id,
            };
            var res = await Mediator.Send(query);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetAll()
        {
            var query = new GetTasksListRequest();
            var res = await Mediator.Send(query);
            return Ok(res);
        }
    }
}