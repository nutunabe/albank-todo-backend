using AlbankTodo.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AlbankTodo.Infrastructure.Data
{
    public class AlbankTodoContext : DbContext
    {
        public AlbankTodoContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TaskConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
