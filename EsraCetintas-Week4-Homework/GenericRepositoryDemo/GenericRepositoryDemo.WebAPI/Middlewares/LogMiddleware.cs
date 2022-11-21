using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.WebAPI.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            var watch = Stopwatch.StartNew();
            await _next.Invoke(httpContext);
            watch.Stop();
            await LogAsync(httpContext, watch);
        }

        private async Task LogAsync(HttpContext httpContext, Stopwatch stopwatch)
        {
            if (stopwatch.ElapsedMilliseconds > 500)
            {
                Trace.TraceInformation($"The passing time : {stopwatch.ElapsedMilliseconds.ToString()} ms. It is more than 500 ms. Request Method : {httpContext.Request.Method}. Request Path : {httpContext.Request.Path}");
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LogMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
