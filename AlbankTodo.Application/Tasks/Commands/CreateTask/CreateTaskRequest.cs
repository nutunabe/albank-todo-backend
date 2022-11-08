using AlbankTodo.Application.Common;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbankTodo.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskRequest : IRequest<ResponseModel>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime DueDate { get; set; }
    }
}
