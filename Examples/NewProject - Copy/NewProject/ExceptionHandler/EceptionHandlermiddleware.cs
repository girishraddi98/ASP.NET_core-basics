
using System.Net;
using System.Text.Json;

namespace NewProject.ExceptionHandler
{
    public class EceptionHandlermiddleware
    {
        private readonly ILogger<EceptionHandlermiddleware> logger;
        private readonly RequestDelegate next;

        public EceptionHandlermiddleware(ILogger<EceptionHandlermiddleware> logger, RequestDelegate request)
        {
            this.logger = logger;
            this.next = request;
        }

        

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An unhandled exception occurred while processing the request.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex switch
            {
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.InternalServerError
            };
            return context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            }));

        }

    }
}
