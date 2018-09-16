using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace fundamentalsProject
{
    // Startup class to use in the Development environment
    // Use the UseStartup(IWebHostBuilder, String) overload that accepts an assembly name:
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-2.1#environment-based-startup-class-and-methods
    /// </summary>
    public class StartupDevelopment
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // ...
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // ...
        }
    }
}
