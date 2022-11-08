using AlbankTodo.Application.Common;
using System;
using Newtonsoft.Json;

namespace AlbankTodo.API.Dtos
{
    public class CreateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime DueDate { get; set; }
    }
}
