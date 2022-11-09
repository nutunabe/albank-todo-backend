using AlbankTodo.Application.Common;
using AlbankTodo.Core.Entities;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace AlbankTodo.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskRequest : IRequest<ResponseModel<TaskDto>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? DueDate { get; set; }
        public Status? Status { get; set; }
    }
}
