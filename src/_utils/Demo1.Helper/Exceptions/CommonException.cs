using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Helper.Exceptions
{
    public class CommonException:Exception
    {        
        public CommonException(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        public CommonException(string errorMessage, HttpStatusCode statusCode)
        {
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }        
        public CommonException(string errorMessage, HttpStatusCode statusCode, object data)
        {
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
            Data = data;
        }
        public string? ErrorMessage { get; set; }
        public object? Data { get; set; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
    }
}
