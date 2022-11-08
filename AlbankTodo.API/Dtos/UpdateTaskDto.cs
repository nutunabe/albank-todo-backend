using AlbankTodo.Application.Common;
using AlbankTodo.Core.Entities;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AlbankTodo.API.Dtos
{
    public class UpdateTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime DueDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
    }
}
