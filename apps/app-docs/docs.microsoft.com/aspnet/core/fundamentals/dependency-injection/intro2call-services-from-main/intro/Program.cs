using System;
using intro.IntroClasses;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace intro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();

            using (IServiceScope serviceScope = host.Services.CreateScope())
            {
                IServiceProvider services = serviceScope.ServiceProvider;

                try
                {
                    MyScopedService serviceContext = services.GetRequiredService<MyScopedService>();
                    // Use the context here
                }
                catch (Exception ex)
                {
                    ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred.");
                }
            }

            host.Run();
        }

        // IWebHostBuilder: A builder for Microsoft.AspNetCore.Hosting.IWebHost.
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            // WebHost: Provides convenience methods for creating instances of Microsoft.AspNetCore.Hosting.IWebHost
            // and Microsoft.AspNetCore.Hosting.IWebHostBuilder with pre-configured defaults.
            // CreateDefaultBuilder: Initializes a new instance of the Microsoft.AspNetCore.Hosting.WebHostBuilder
            // class with pre-configured defaults.
            IWebHostBuilder webHostBuilder = WebHost.CreateDefaultBuilder(args);
            // Startup: Specify the startup type to be used by the web host.
            IWebHostBuilder hostBuilder = webHostBuilder.UseStartup<Startup>();
            return hostBuilder;
        }
    }
}
