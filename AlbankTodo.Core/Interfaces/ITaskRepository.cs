using AlbankTodo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbankTodo.Core.Interfaces
{
    public interface ITaskRepository
    {
        void AddTask(AlbankTask task);
        void DeleteTask(AlbankTask task);
        void UpdateTask(AlbankTask task);
        Task<AlbankTask> GetTaskAsync(int id);
        Task<IEnumerable<AlbankTask>> GetAllTasksAsync();
    }
}
