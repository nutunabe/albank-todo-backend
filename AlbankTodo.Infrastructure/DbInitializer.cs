using AlbankTodo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbankTodo.Infrastructure
{
    public class DbInitializer
    {
        public static void Initialize(AlbankTodoContext context) =>
            context.Database.EnsureCreated();
    }
}
