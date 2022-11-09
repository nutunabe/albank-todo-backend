using FluentValidation;
using System;

namespace AlbankTodo.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskRequestValidator : AbstractValidator<UpdateTaskRequest>
    {
        public UpdateTaskRequestValidator()
        {
            RuleFor(updateTaskRequest => updateTaskRequest.Id).NotNull().GreaterThan(0);
            RuleFor(updateTaskRequest => updateTaskRequest.Title).MaximumLength(128);
            RuleFor(updateTaskRequest => updateTaskRequest.Description).MaximumLength(1024);
            RuleFor(updateTaskRequest => updateTaskRequest.DueDate).GreaterThanOrEqualTo(DateTime.Today).When(x => x != null);
            RuleFor(updateTaskRequest => updateTaskRequest.Status).IsInEnum().When(x => x != null);
        }
    }
}
