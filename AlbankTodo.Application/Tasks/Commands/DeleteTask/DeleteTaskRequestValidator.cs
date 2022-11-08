using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
