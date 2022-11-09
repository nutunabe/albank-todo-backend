using AlbankTodo.Core.Entities;
using AlbankTodo.Core.Interfaces;
using AlbankTodo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbankTodo.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DbSet<AlbankTask> _dbSet;

        public TaskRepository(AlbankTodoContext todoContext) =>
            _dbSet = todoContext.Set<AlbankTask>();

        public void AddTask(AlbankTask task) => _dbSet.Add(task);

        public void DeleteTask(AlbankTask task) => _dbSet.Remove(task);

        public void UpdateTask(AlbankTask task) => _dbSet.Update(task);

        public async Task<AlbankTask> GetTaskAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AlbankTask>> GetAllTasksAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<(IEnumerable<AlbankTask>, int)> GetTasksPageAsync(int pageNumber, int pageSize)
        {
            var count = await _dbSet.CountAsync();
            var tasks = await _dbSet.Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();
            return (tasks, count);
        }

        public async Task<AlbankTask> GetRecycledTaskAsync(int id)
        {
            return await _dbSet.IgnoreQueryFilters().Where(x => x.IsRecycled).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AlbankTask>> GetAllRecycledTasksAsync()
        {
            return await _dbSet.IgnoreQueryFilters().Where(x => x.IsRecycled).ToListAsync();
        }

        public void DeleteAllRecycledTasks() =>
            _dbSet.RemoveRange(_dbSet.IgnoreQueryFilters().Where(x => x.IsRecycled));

        public void RestoreAllRecycledTasks()
        {
            var recycledTasks = _dbSet.IgnoreQueryFilters().Where(x => x.IsRecycled).ToList();
            recycledTasks.ForEach(x => x.IsRecycled = false);
        }
    }
}
