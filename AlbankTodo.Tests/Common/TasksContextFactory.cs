using AlbankTodo.Core.Entities;
using AlbankTodo.Infrastructure.Data;
using AlbankTodo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace AlbankTodo.Tests.Common
{
    public class TasksContextFactory
    {
        public static int TaskIdForDelete = 11;
        public static int TaskIdForUpdate = 21;

        public static (AlbankTodoContext, TaskRepository) Create()
        {
            var options = new DbContextOptionsBuilder<AlbankTodoContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new AlbankTodoContext(options);
            context.Database.EnsureCreated();
            context.Set<AlbankTask>().AddRange(
                new AlbankTask
                {
                    Id = 1,
                    Title = "Title 1",
                    Description = "Description 1",
                    DueDate = new DateTime(2022, 11, 10),
                    CreatedOn = DateTime.Today,
                    CompletedOn = null,
                    Status = Status.CREATED
                },
                new AlbankTask
                {
                    Id = 2,
                    Title = "Title 2",
                    Description = "Description 2",
                    DueDate = new DateTime(2022, 11, 10),
                    CreatedOn = DateTime.Today,
                    CompletedOn = null,
                    Status = Status.CREATED
                },
                new AlbankTask
                {
                    Id = TaskIdForDelete,
                    Title = "Title 3",
                    Description = "Description 3",
                    DueDate = new DateTime(2022, 11, 10),
                    CreatedOn = DateTime.Today,
                    CompletedOn = null,
                    Status = Status.CREATED
                },
                new AlbankTask
                {
                    Id = TaskIdForUpdate,
                    Title = "Title 4",
                    Description = "Description 4",
                    DueDate = new DateTime(2022, 11, 10),
                    CreatedOn = DateTime.Today,
                    CompletedOn = null,
                    Status = Status.CREATED
                }
                );
            context.SaveChanges();
            TaskRepository taskRepository = new TaskRepository(context);
            return (context, taskRepository);
        }

        public static void Destroy(AlbankTodoContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
