using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaskManager.Exceptions
{
    public class ErrorHandlingMiddleware
    {

        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlingMiddleware> logger;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception exc)
            {
                logger.LogError(exc, exc.Message);
                await HandlerExceptionAsync(context, exc);
            }
        }

        private Task HandlerExceptionAsync(HttpContext context, Exception exc)
        {
            var code = HttpStatusCode.InternalServerError;
            var exceptionMessage = new HttpResponseExceptionMessage
            {
                Status = code,
                TraceID = context.TraceIdentifier,
                Message = exc.Message
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonSerializer.Serialize(exceptionMessage));
        }
    }
}
