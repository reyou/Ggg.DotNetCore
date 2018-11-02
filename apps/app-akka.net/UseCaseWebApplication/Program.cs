using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace UseCaseWebApplication
{
    /// <summary>
    /// https://getakka.net/articles/intro/use-case-and-deployment-scenarios.html#aspnet
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
