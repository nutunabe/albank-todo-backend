using AlbankTodo.Application.Common;
using MediatR;
using Newtonsoft.Json;
using System;

namespace AlbankTodo.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskRequest : IRequest<ResponseModel<TaskDto>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime DueDate { get; set; }
    }
}
