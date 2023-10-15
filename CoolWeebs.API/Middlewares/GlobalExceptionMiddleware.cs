using CoolWeebs.API.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoolWeebs.API.Middlewares
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while processing the request.");

                await context.Response.WriteAsJsonAsync(e.ToProblemDetails());
            }
        }
    }
}
