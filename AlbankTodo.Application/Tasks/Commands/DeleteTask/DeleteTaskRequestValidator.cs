using FluentValidation;

namespace AlbankTodo.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskRequestValidator : AbstractValidator<DeleteTaskRequest>
    {
        public DeleteTaskRequestValidator()
        {
            RuleFor(deleteTaskRequest => deleteTaskRequest.Id).NotNull().GreaterThan(0);
        }
    }
}
