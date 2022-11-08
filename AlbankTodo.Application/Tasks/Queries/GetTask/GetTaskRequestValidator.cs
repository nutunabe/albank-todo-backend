using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
