using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
