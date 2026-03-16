using System;
using System.Net;
using System.Text.Json;

namespace Monoexample.Middleware
{
    public class ExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> logger;
        private readonly RequestDelegate request;
        public ExceptionHandler(ILogger<ExceptionHandler> logger1, RequestDelegate request)
        {
            this.logger = logger1;
            Request = request;
        }

        public RequestDelegate Request;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await Request(context);

            }
            catch (Exception ex) {

                logger.LogError(ex, "Unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);

            }

        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        { 
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = ex switch
        {
            ArgumentException => StatusCodes.Status400BadRequest,
            
            KeyNotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

            return context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            }));

        }
}
}
