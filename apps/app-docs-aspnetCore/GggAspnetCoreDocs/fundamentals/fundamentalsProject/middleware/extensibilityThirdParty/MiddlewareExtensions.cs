using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace fundamentalsProject.middleware.extensibilityThirdParty
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseSimpleInjectorActivatedMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SimpleInjectorActivatedMiddleware>();
        }
    }
}
