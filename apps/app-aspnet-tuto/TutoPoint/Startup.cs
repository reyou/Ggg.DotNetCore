using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TutoPoint.Models;

namespace TutoPoint
{
    // https://didyoureadme.azurewebsites.net/UserUrls/TagUrls?UserUrlTagId=245911fe-5d21-4c86-8311-6ab2441fe268&WillRead=True
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("AppSettings.json");
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit 
        // https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //=================================================================
            // Adds MVC services to the specified IServiceCollection.
            services.AddMvc();
            string connectionString = Configuration["database:connection"];
            //=================================================================
            /*You only need to use this functionality when you want Entity Framework to
             resolve the services it uses from an external dependency injection container. 
             If you are not using an external dependency injection container, 
             Entity Framework will take care of creating the services it requires.*/
            // https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext
            //services.AddEntityFrameworkSqlServer()
            //    .AddDbContext<FirstAppDemoDbContext>
            //        (option => option.UseSqlServer(connectionString));

            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<FirstAppDemoDbContext>((serviceProvider, options) =>
                    options.UseSqlServer(connectionString)
                        .UseInternalServiceProvider(serviceProvider));

            //=================================================================
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // IApplicationBuilder: Defines a class that provides the mechanisms to configure an application's request pipeline
        // IHostingEnvironment: Provides information about the web hosting environment an application is running in
        // ILoggerFactory: Represents a type used to configure the logging system and 
        // create instances of ILogger from the registered ILoggerProviders
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Adds the WelcomePageMiddleware to the pipeline
            //app.UseWelcomePage();  

            /*The order in which you install the middleware is important because 
             if you had UseDefaultFiles after UseStaticFiles, you would not get 
             the same result.*/

            // Enables default file mapping on the current path
            app.UseDefaultFiles();

            // Enables static file serving for the current request path
            app.UseStaticFiles();

            /*Adds MVC to the IApplicationBuilder request execution pipeline with a default route
             named 'default' and the following template: '{controller=Home}/{action=Index}/{id?}'.*/
            // app.UseMvcWithDefaultRoute();

            // Adds MVC to the IApplicationBuilder request execution pipeline.
            app.UseMvc(ConfigureRoute);

            // Enable all static file middleware (except directory browsing) 
            // for the current request path in the current directory
            app.UseFileServer();

            // Adds a console logger that is enabled for LogLevel.Information or higher
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                /*Captures synchronous and asynchronous Exception instances
                 from the pipeline and generates HTML error responses.*/
                /*UseDeveloperExceptionPage(IApplicationBuilder)
                Captures synchronous and asynchronous Exception instances from the 
                pipeline and generates HTML error responses.*/
                app.UseDeveloperExceptionPage();
            }
            // Adds a terminal middleware delegate to the application's 
            // request pipeline
            app.Run(Handler);
            // this is not executing seems like
            // app.Run(GggHandler);
        }

        private void ConfigureRoute(IRouteBuilder routeBuilder)
        {
            //Home/Index 
            routeBuilder.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
        }

        // ReSharper disable once UnusedMember.Local
        private async Task GggHandler(HttpContext context)
        {
            await context.Response.WriteAsync("Ggg Handler");
        }

        private async Task Handler(HttpContext context)
        {
            string qqq = "abc";
            if (qqq.Length > 5)
            {
                throw new System.Exception("Throw Exception");
            }
            string msg = Configuration["message"];
            // Writes the given text to the response body. UTF-8 encoding will be used
            await context.Response.WriteAsync(msg);
        }
    }
}
