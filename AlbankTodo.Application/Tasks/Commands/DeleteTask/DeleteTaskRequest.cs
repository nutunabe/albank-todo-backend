using AlbankTodo.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbankTodo.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskRequest : IRequest<ResponseModel>
    {
        public int Id { get; set; }
    }
}
