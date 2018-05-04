using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace GggRazorPages
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        // Represents a configured web host
        public static IWebHost BuildWebHost(string[] args)
        {
            // Initializes a new instance of the WebHostBuilder class with pre-configured defaults
            IWebHostBuilder webHostBuilder = WebHost.CreateDefaultBuilder(args);
            // Specify the startup type to be used by the web host
            IWebHostBuilder hostBuilder = webHostBuilder.UseStartup<Startup>();
            // Builds an IWebHost which hosts a web application
            IWebHost webHost = hostBuilder.Build();
            return webHost;
        }
    }
}
