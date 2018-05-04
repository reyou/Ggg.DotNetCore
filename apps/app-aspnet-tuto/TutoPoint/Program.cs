using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace TutoPoint
{
    // https://didyoureadme.azurewebsites.net/UserUrls/TagUrls?UserUrlTagId=245911fe-5d21-4c86-8311-6ab2441fe268&WillRead=True
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
        // https://github.com/aspnet/Announcements/issues/164
        public static IWebHost BuildWebHost(string[] args)
        {
            /*Provides convenience methods for creating instances of
             IWebHost and IWebHostBuilder with pre-configured defaults.*/
            IWebHostBuilder webHostBuilder = WebHost.CreateDefaultBuilder(args);
            // Specify the startup type to be used by the web host.
            IWebHostBuilder hostBuilder = webHostBuilder.UseStartup<Startup>();
            // Builds an IWebHost which hosts a web application
            IWebHost webHost = hostBuilder.Build();
            return webHost;
        }
    }
}
