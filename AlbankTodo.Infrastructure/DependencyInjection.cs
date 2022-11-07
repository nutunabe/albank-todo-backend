using AlbankTodo.Core.Interfaces;
using AlbankTodo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlbankTodo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration["DbConnection"];
            services.AddDbContext<AlbankTodoContext>(options => options.UseNpgsql(connString));
            //services.AddScoped<IAlbankTodoContext>(provider => provider.GetService<AlbankTodoContext>());
            return services;
        }
    }
}
