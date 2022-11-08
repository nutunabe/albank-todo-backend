using AlbankTodo.Core.Entities;
using System.Collections.Generic;
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
        Task<(IEnumerable<AlbankTask>, int)> GetTasksPageAsync(int pageNumber, int pageSize);
    }
}
