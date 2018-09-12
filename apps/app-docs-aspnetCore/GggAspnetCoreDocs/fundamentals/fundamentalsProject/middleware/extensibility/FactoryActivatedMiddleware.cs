using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace fundamentalsProject.middleware.extensibility
{
    public class FactoryActivatedMiddleware : IMiddleware
    {
        private readonly AppDbContext _db;

        public FactoryActivatedMiddleware(AppDbContext db)
        {
            _db = db;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            StringValues keyValue = context.Request.Query["key"];

            if (!string.IsNullOrWhiteSpace(keyValue))
            {
                _db.Add(new Request()
                {
                    DT = DateTime.UtcNow,
                    MiddlewareActivation = "FactoryActivatedMiddleware",
                    Value = keyValue
                });

                await _db.SaveChangesAsync();
            }

            await next(context);
        }
    }
}
