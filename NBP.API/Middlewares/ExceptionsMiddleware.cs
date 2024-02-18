using NBP.API.Errors;
using System.Net;
using System.Text.Json;

namespace NBP.API.Middlewares
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            ApiError response;
            await _next(context);

            if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
            {
                // Kreiranje i slanje poruke o grešci kao JSON odgovor
                context.Response.ContentType = "application/json";
                response = new ApiError((int)HttpStatusCode.Forbidden, "You are not authorized.", "Please login to perform this action.");
                var result = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(result);
            }
            if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
            {
                // Kreiranje i slanje poruke o grešci kao JSON odgovor
                context.Response.ContentType = "application/json";
                response = new ApiError((int)HttpStatusCode.NotFound, "Not found.", "Nece da moze.");
                var result = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(result);
            }
            if (context.Response.StatusCode == (int)HttpStatusCode.MethodNotAllowed)
            {
                // Kreiranje i slanje poruke o grešci kao JSON odgovor
                context.Response.ContentType = "application/json";
                response = new ApiError((int)HttpStatusCode.MethodNotAllowed, "Method is not allowed.", "A request method is not supported for the requested resource.");
                var result = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(result);
            }
            if (context.Response.StatusCode == (int)HttpStatusCode.UnsupportedMediaType)
            {
                // Kreiranje i slanje poruke o grešci kao JSON odgovor
                context.Response.ContentType = "application/json";
                response = new ApiError((int)HttpStatusCode.UnsupportedMediaType, "Unsupported media type.",
                    "The request entity has a media type which the server or resource does not support.");
                var result = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(result);
            }
            else
            {
                context.Response.ContentType = "application/json";
                response = new ApiError((int)HttpStatusCode.InternalServerError, "Something went wrong.",
                    "Please be patient.");
                var result = JsonSerializer.Serialize(response); //convert object to json
                await context.Response.WriteAsync(result);
            }
        }
    }
}
