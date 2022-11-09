﻿using AlbankTodo.Core.Interfaces;
using AlbankTodo.Infrastructure.Data;
using AlbankTodo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AlbankTodo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //var connString = configuration["DbConnection"];
            var connString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            services.AddDbContext<AlbankTodoContext>(options => options.UseNpgsql(connString));
            //services.AddScoped<IAlbankTodoContext>(provider => provider.GetService<AlbankTodoContext>());
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
