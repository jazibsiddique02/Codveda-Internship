using Serilog;
using System.Diagnostics;
using System.IO;

namespace MiniProductCatalog.Middlewares
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopWatch = Stopwatch.StartNew();

            await _next(context); // Call next middleware in pipeline

            stopWatch.Stop();

            var elapsedMilliseconds = stopWatch.ElapsedMilliseconds;
            var Path = context.Request.Path.ToString();

            // Ignore logging for static files like CSS, JS, images
            var ignoredExtensions = new[] { ".css", ".js", ".png", ".jpg", ".jpeg", ".gif", ".svg", ".ico", ".woff", ".woff2", ".ttf" };
            if (ignoredExtensions.Any(ext => Path.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
            {
                return; // Skip logging for these files
            }

            // Log the request timing information
            Log.Information($"Request to {Path} took {elapsedMilliseconds}ms");

        }






    }
}
