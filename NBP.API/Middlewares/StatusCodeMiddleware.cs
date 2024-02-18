using System.Net;

namespace NBP.API.Middlewares
{
    public class StatusCodeMiddleware
    {
        private readonly RequestDelegate _next;

        public StatusCodeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == (int)HttpStatusCode.OK)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Created;
            }
            else if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}
