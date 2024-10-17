using Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace Presentation_API.Middlewares
{
    public class NotFoundExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public NotFoundExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (NotFoundValidationException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, NotFoundValidationException exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var statusCode = HttpStatusCode.NotFound;
            var result = JsonSerializer.Serialize(new
            {
                error = exception.Message,
                detail = exception.InnerException?.Message
            });
            response.StatusCode = (int)statusCode;
            await response.WriteAsync(result);
        }
    }
}
