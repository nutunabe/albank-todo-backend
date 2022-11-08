using AlbankTodo.Application.Common;
using AlbankTodo.Core.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace AlbankTodo.Application.Tasks.Queries
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime DueDate { get; set; }
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime CreatedOn { get; set; }
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime CompletedOn { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
    }
}
