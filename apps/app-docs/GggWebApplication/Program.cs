using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace GggWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Represents a configured web host.
            IWebHost buildWebHost = BuildWebHost(args);
            // Runs a web application and block the calling thread until host shutdown.
            buildWebHost.Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            /*WebHost Class: Provides convenience methods for creating instances
             of IWebHost and IWebHostBuilder with pre-configured defaults.*/
            IWebHostBuilder webHostBuilder = WebHost.CreateDefaultBuilder(args);
            // Specify the startup type to be used by the web host.
            IWebHostBuilder hostBuilder = webHostBuilder.UseStartup<Startup>();
            // Builds an IWebHost which hosts a web application.
            IWebHost webHost = hostBuilder.Build();
            return webHost;
        }
    }
}
