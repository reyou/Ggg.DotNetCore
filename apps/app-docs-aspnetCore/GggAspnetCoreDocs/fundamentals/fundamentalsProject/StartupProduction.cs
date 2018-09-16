using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace fundamentalsProject
{
    // Startup class to use in the Production environment
    // Use the UseStartup(IWebHostBuilder, String) overload that accepts an assembly name:
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-2.1#environment-based-startup-class-and-methods
    /// </summary>
    public class StartupProduction
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
