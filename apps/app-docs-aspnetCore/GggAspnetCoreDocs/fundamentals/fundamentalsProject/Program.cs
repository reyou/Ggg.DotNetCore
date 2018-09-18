using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace fundamentalsProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup?view=aspnetcore-2.1#convenience-methods
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            Action<WebHostBuilderContext, IConfigurationBuilder> configBuilder = ConfigBuilder;
            return WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration(configBuilder)
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole(options => options.IncludeScopes = true);
                    logging.AddDebug();
                })
                .UseStartup<Startup>();
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.1#providers
        /// </summary>
        /// <param name="hostingContext"></param>
        /// <param name="config"></param>
        private static void ConfigBuilder(WebHostBuilderContext hostingContext, IConfigurationBuilder config)
        {
            Dictionary<string, string> arrayDict = new Dictionary<string, string>{
            {"array:entries:0", "value0"},
            {"array:entries:1", "value1"},
            {"array:entries:2", "value2"},
            {"array:entries:4", "value4"},
            {"array:entries:5", "value5"}
        };
            config.SetBasePath(Directory.GetCurrentDirectory());
            config.AddInMemoryCollection(arrayDict);
            config.AddJsonFile("json_array.json", optional: false, reloadOnChange: false);
            config.AddJsonFile("starship.json", optional: false, reloadOnChange: false);
            config.AddXmlFile("tvshow.xml", optional: false, reloadOnChange: false);
        }
    }
}
