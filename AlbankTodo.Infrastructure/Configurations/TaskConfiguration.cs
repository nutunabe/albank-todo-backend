using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlbankTodo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlbankTodo.Infrastructure.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<AlbankTask>
    {
        public void Configure(EntityTypeBuilder<AlbankTask> builder)
        {
            builder.HasKey(task => task.Id);
            builder.Property(task => task.Title).HasMaxLength(128);
            builder.Property(task => task.Description).HasMaxLength(1024);
            builder.Property(task => task.DueDate);
            builder.Property(task => task.CreatedOn);
            builder.Property(task => task.CompletedOn);
            builder.Property(task => task.Status);
        }
    }
}
