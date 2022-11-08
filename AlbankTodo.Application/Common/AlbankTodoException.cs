using System;
using System.Net;

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
