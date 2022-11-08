using System;
using System.Threading.Tasks;

namespace AlbankTodo.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Complete();
    }
}
