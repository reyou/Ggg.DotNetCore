using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fundamentalsProject.middleware.extensibility;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace fundamentalsProject.middleware.extensibilityThirdParty
{
    public class SimpleInjectorActivatedMiddleware : IMiddleware
    {
        private readonly AppDbContext _db;

        public SimpleInjectorActivatedMiddleware(AppDbContext db)
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
                    MiddlewareActivation = "SimpleInjectorActivatedMiddleware",
                    Value = keyValue
                });

                await _db.SaveChangesAsync();
            }

            await next(context);
        }
    }
}
