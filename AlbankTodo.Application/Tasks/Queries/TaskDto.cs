using AlbankTodo.Core.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using AlbankTodo.Application.Common;

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
