using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlbankTodo.Application.Common
{
    public class AlbankTodoException : Exception
    {
        public HttpStatusCode ErrorCode { get; set; }
        public AlbankTodoException(HttpStatusCode errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
