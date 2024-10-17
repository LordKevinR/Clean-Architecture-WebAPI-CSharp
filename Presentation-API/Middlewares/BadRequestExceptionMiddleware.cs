using Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace Presentation_API.Middlewares
{
    public class BadRequestExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public BadRequestExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (BadRequestValidationException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, BadRequestValidationException exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var statusCode = HttpStatusCode.BadRequest;
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
