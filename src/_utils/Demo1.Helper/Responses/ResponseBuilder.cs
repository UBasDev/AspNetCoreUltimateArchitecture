using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Helper.Responses
{
    public static class ResponseBuilder
    {
        public static BaseResponse<T> Build<T>(T response)
        {
            return new BaseResponse<T>(payload: response);
        }
    }
}
