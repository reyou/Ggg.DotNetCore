using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
            /*Initializes a new instance of the WebHostBuilder class with pre-configured
             defaults*/
            IWebHostBuilder webHostBuilder = WebHost.CreateDefaultBuilder(args);
            // Specify the startup type to be used by the web host.
            IWebHostBuilder hostBuilder = webHostBuilder.UseStartup<Startup>();

            // Adds a delegate for configuring the provided LoggerFactory.
            // This may be called multiple times.
            IWebHostBuilder configureLogging = hostBuilder.ConfigureLogging(ConfigureLogging);

            // Builds an IWebHost which hosts a web application.
            IWebHost webHost = configureLogging.Build();
            return webHost;
        }

        // WebHostBuilderContext Class
        // Context containing the common services on the IWebHost.
        // Some properties may be null until set by the IWebHost.
        // ILoggingBuilder Interface
        // An interface for configuring logging providers
        private static void ConfigureLogging(WebHostBuilderContext hostingContext, ILoggingBuilder logging)
        {
            IConfigurationSection configurationSection = hostingContext.Configuration.GetSection("Logging");
            // Configures LoggerFilterOptions from an instance of IConfiguration
            logging.AddConfiguration(configurationSection);
            // Adds a console logger that is enabled for LogLevel.Information or higher
            logging.AddConsole();
            // Adds a debug logger that is enabled for LogLevel.Information or higher
            logging.AddDebug();
        }
    }
}
