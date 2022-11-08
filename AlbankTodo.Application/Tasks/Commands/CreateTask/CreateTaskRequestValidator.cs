using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace AlbankTodo.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequest>
    {
        public CreateTaskRequestValidator()
        {
            RuleFor(createTaskRequest => createTaskRequest.Title).NotEmpty().MaximumLength(128);
            RuleFor(createTaskRequest => createTaskRequest.Description).MaximumLength(1024);
            RuleFor(createTaskRequest => createTaskRequest.DueDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Today);
        }
    }
}
