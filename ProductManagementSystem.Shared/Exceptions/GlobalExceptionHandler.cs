using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace ProductManagementSystem.Shared.Exceptions
{
    public class GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An unexpected error occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is NotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                var notFoundErrorResponse = new
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Resource not found",
                    Detailed = exception.Message
                };

                return context.Response.WriteAsync(JsonConvert.SerializeObject(notFoundErrorResponse));
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var errorResponse = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "An unexpected error occurred. Please try again later.",
                Detailed = exception.Message 
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }
    }
}

