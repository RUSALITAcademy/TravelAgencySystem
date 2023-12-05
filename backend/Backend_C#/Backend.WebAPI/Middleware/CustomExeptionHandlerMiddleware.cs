using Backend.Application.Common.Exceptions;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace Backend.WebAPI.Middleware
{
    public class CustomExeptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExeptionHandlerMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exeption)
            {
                await HandleExeptionAsync(context, exeption);
            }
        }

        public Task HandleExeptionAsync(HttpContext context, Exception exeption)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (exeption)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = exeption.Message });
            }

            return context.Response.WriteAsync(result);
        }

    }
}
