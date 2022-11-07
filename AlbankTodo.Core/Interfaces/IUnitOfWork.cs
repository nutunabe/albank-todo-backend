﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbankTodo.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Complete();
    }
}
