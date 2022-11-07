using AlbankTodo.Core.Entities;
using System;

namespace AlbankTodo.API.Dtos
{
    public class UpdateTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
    }
}
