using Demo1.Helper.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Helper.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        private ILogger<ExceptionMiddleware> _logger;
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger = context.RequestServices.GetRequiredService<ILogger<ExceptionMiddleware>>();
            try
            {
                await next(context);
            }
            catch (CommonException ex)
            {
                //var currentUserId = (context.User?.Identity as ClaimsIdentity)?.FindFirst(JwtClaimTypes.Id)?.Value;
                //_logger.LogInformation(ex, "{Type} {Status} {CreatedDate} - {UserId} - {@Data}", "LdsException", "Info", DateTimeOffset.UtcNow, currentUserId, ex.Data);
                _logger.LogInformation(ex, "{Type} {Status} {CreatedDate} - {@Data}", "LdsException", "Info", DateTimeOffset.UtcNow, ex.Data);
                context.Response.StatusCode = (int)ex.StatusCode;
                await context.Response.WriteAsJsonAsync(new BaseExceptionResponse()
                {
                    Payload = new BaseExceptionResponseBody()
                    {
                        ErrorMessage = ex.ErrorMessage ?? String.Empty,
                        StatusCode = ex.StatusCode
                    }
                });
            }
            
            catch (Exception ex)
            {
                //var currentUserId = (context.User?.Identity as ClaimsIdentity)?.FindFirst(JwtClaimTypes.Id)?.Value;
                var expId = (int)DateTimeOffset.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                //_logger.LogError(e, "{Type} {Status} {CreatedDate} - {UserId} - {ExpId}", "Exception", "Error", DateTimeOffset.UtcNow, currentUserId, expId);
                _logger.LogError(ex, "{Type} {Status} {CreatedDate} - {ExpId}", "Exception", "Error", DateTimeOffset.UtcNow, expId);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var message = _logger.IsEnabled(LogLevel.Debug)
                    ? ex.Message
                    : $"Lütfen daha sonra tekrar deneyiniz. ExpId:{expId}";
                await context.Response.WriteAsJsonAsync(new BaseExceptionResponse()
                {
                    Payload = new BaseExceptionResponseBody()
                    {
                        ErrorMessage = message,
                        StatusCode = HttpStatusCode.InternalServerError
                    }
                });
            }
            
        }
    }
}
