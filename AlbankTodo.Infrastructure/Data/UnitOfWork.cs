using AlbankTodo.Core.Interfaces;
using System.Threading.Tasks;

namespace AlbankTodo.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AlbankTodoContext _context;

        public UnitOfWork(AlbankTodoContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
