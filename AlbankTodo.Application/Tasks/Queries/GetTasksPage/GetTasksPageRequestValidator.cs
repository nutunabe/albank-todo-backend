using FluentValidation;

namespace AlbankTodo.Application.Tasks.Queries.GetTasksPage
{
    public class GetTasksPageRequestValidator : AbstractValidator<GetTasksPageRequest>
    {
        public GetTasksPageRequestValidator()
        {
            RuleFor(getTasksPageRequest => getTasksPageRequest.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(getTasksPageRequest => getTasksPageRequest.PageSize).GreaterThanOrEqualTo(1);
        }
    }
}
