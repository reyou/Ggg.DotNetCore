using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

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
            ILoggingBuilder addConfiguration = logging.AddConfiguration(configurationSection);
            // Adds a console logger that is enabled for LogLevel.Information or higher
            ILoggingBuilder loggingBuilder = addConfiguration.AddConsole(options => options.IncludeScopes = true);
            // Adds a debug logger that is enabled for LogLevel.Information or higher
            ILoggingBuilder addDebug = loggingBuilder.AddDebug();
            // You can register filter rules in code, as shown in the following example
            /*The second AddFilter specifies the Debug provider by using its type name.
             The first AddFilter applies to all providers because it doesn't specify a 
             provider type.*/
            ILoggingBuilder addFilter = addDebug.AddFilter("System", LogLevel.Debug);
            ILoggingBuilder debugFilter = addFilter.AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace);
            /*There's a minimum level setting that takes effect only if no rules from
             configuration or code apply for a given provider and category. The following example 
             shows how to set the minimum level:*/
            ILoggingBuilder minimumLevel = debugFilter.SetMinimumLevel(LogLevel.Information);
            /*You can write code in a filter function to apply filtering rules. A filter
             function is invoked for all providers and categories that don't have rules assigned 
             to them by configuration or code. Code in the function has access to the provider type, 
             category, and log level to decide whether or not a message should be logged*/
            minimumLevel.AddFilter((provider, category, logLevel) =>
            {
                if (provider == "Microsoft.Extensions.Logging.Console.ConsoleLoggerProvider" &&
                    category == "TodoApi.Controllers.TodoController")
                {
                    return false;
                }
                return true;
            });

        }
    }
}
