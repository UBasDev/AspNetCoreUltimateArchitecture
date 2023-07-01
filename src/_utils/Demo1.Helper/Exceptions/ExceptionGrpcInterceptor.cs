using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Helper.Exceptions
{
    public class ExceptionGrpcInterceptor: Interceptor
    {
        private readonly ILogger<ExceptionGrpcInterceptor> _logger;

        public ExceptionGrpcInterceptor(ILogger<ExceptionGrpcInterceptor> logger)
        {
            _logger = logger;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(request, context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Type} {Status} {CreatedDate}", "Exception", "Error", DateTimeOffset.UtcNow);
                throw;
            }
        }
    }
}
