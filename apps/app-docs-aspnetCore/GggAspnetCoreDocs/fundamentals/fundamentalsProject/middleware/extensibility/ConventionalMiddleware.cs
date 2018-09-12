using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace fundamentalsProject.middleware.extensibility
{
    public class ConventionalMiddleware
    {
        // A function that can process an HTTP request.
        private readonly RequestDelegate _next;

        public ConventionalMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, AppDbContext db)
        {
            StringValues keyValue = context.Request.Query["key"];

            if (!string.IsNullOrWhiteSpace(keyValue))
            {
                db.Add(new Request()
                {
                    DT = DateTime.UtcNow,
                    MiddlewareActivation = "ConventionalMiddleware",
                    Value = keyValue
                });

                await db.SaveChangesAsync();
            }

            await _next(context);
        }
    }
}
