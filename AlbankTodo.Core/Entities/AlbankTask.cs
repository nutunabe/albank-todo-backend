using System;

namespace AlbankTodo.Core.Entities
{
    public enum Status { Created, InProgress, Completed }
    public class AlbankTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public Status Status { get; set; }
        public bool IsRecycled { get; set; }
    }
}
