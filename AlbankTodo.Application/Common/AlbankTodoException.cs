using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbankTodo.Application.Common
{
    public class AlbankTodoException : Exception
    {
        public string ErrorCode { get; set; }
        public AlbankTodoException(string errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
