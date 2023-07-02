using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Helper.Responses
{
    public class BaseExceptionResponse
    {
        public BaseExceptionResponseBody Payload { get; set; }    
    }
    public class BaseExceptionResponseBody
    {
        public BaseExceptionResponseBody()
        {
            ErrorMessage = string.Empty;
            StatusCode = HttpStatusCode.InternalServerError;
        }
        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
