using FluentValidation;
using System;

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
