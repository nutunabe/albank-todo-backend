using AlbankTodo.Infrastructure.Data;

namespace AlbankTodo.Infrastructure
{
    public class DbInitializer
    {
        public static void Initialize(AlbankTodoContext context) =>
            context.Database.EnsureCreated();
    }
}
