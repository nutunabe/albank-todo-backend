using AlbankTodo.API.Helpers;
using AlbankTodo.Core.Interfaces;
using AlbankTodo.Infrastructure.Data;
using AutoMapper;
using System;

namespace AlbankTodo.Tests.Common
{
    public abstract class TestRequestBase : IDisposable
    {
        protected readonly AlbankTodoContext Context;
        protected readonly ITaskRepository Repository;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;

        public TestRequestBase()
        {
            (Context, Repository) = TasksContextFactory.Create();
            UnitOfWork = new UnitOfWork(Context);
            var configurationBuilder = new MapperConfiguration(config =>
            {
                config.AddProfile(typeof(MappingProfiles));
            });
            Mapper = configurationBuilder.CreateMapper();
        }

        public void Dispose()
        {
            TasksContextFactory.Destroy(Context);
        }
    }
}
