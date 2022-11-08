using FluentValidation;

namespace AlbankTodo.Application.Tasks.Queries.GetTask
{
    public class GetTaskRequestValidator : AbstractValidator<GetTaskRequest>
    {
        public GetTaskRequestValidator()
        {
            RuleFor(getTaskRequest => getTaskRequest.Id).NotNull().GreaterThan(0);
        }
    }
}
