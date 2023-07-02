using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Helper.Responses
{
    public class BaseResponse
    {
        public int ServerTime { get; set; } = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
    }
    public class BaseResponse<T> : BaseResponse
    {
        public BaseResponse(T payload)
        {
            Payload = payload;
        }

        public T Payload { get; private set; }
    }
}
