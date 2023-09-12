using ProductMgmt.Core;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace ProductMgmtApi.Middlerwares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var watch = new Stopwatch();
            watch.Start();
            try
            {
                await next.Invoke(context);
                watch.Stop();
            }
            catch (KnownException ex)
            {
                watch.Stop();
                await HandleExceptionMessageAsync(context, ex, HttpStatusCode.UnprocessableEntity, watch.Elapsed);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleExceptionMessageAsync(context, ex, (HttpStatusCode)context.Response.StatusCode, watch.Elapsed);
            }
        }

        private async Task HandleExceptionMessageAsync(HttpContext context, Exception exception, HttpStatusCode statusCode, TimeSpan timeSpan)
        {
            var response = JsonSerializer.Serialize(new ApiResponse()
            {
                CallDuration = timeSpan,
                IsSuccess = false,
                Message = exception.Message,
                StatusCode = statusCode
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsync(response);
        }
    }
}
