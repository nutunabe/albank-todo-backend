using AlbankTodo.Application.Tasks.Commands.CreateTask;
using AlbankTodo.Core.Entities;
using FluentValidation;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbankTodo.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskRequestValidator : AbstractValidator<UpdateTaskRequest>
    {
        public UpdateTaskRequestValidator()
        {
            RuleFor(updateTaskRequest => updateTaskRequest.Id).NotNull().GreaterThan(0); ;
            RuleFor(updateTaskRequest => updateTaskRequest.Title).NotEmpty().MaximumLength(128);
            RuleFor(updateTaskRequest => updateTaskRequest.Description).MaximumLength(1024);
            RuleFor(updateTaskRequest => updateTaskRequest.DueDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Today);
            RuleFor(updateTaskRequest => updateTaskRequest.Status).IsInEnum();
        }
    }
}
