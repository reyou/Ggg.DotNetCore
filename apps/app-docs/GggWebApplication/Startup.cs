using GggWebApplication.Filters;
using GggWebApplication.Filters.Attributes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Globalization;

namespace GggWebApplication
{
    public class Startup
    {
        // Represents a set of key/value application configuration properties
        public Startup(IConfiguration configuration)
        {
            Console.WriteLine("GggMessage: App Started!");
            Console.WriteLine("GggMessage: ProcessId: " + Process.GetCurrentProcess().Id);
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Specifies the contract for a collection of service descriptors
        public void ConfigureServices(IServiceCollection services)
        {
            // Adds MVC services to the specified IServiceCollection
            // https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1#feedback
            services.AddMvc(options =>
            {
                options.Filters.Add(new AddHeaderAttribute("GlobalAddHeader",
                    "Result filter added to MvcOptions.Filters")); // an instance
                options.Filters.Add(typeof(SampleActionFilter)); // by type
                options.Filters.Add(new SampleGlobalActionFilter()); // an instance
                options.Filters.Add(new AddHeaderFilterWithDi2(null)); // an instance
            });

            // AddScoped: Adds a scoped service of the type specified in serviceType
            // to the specified IServiceCollection
            services.AddScoped<AddHeaderFilterWithDi>();

        }

        // This method gets called by the runtime. 
        // Use this method to configure the HTTP request pipeline.
        /*IApplicationBuilder: Defines a class that provides the mechanisms to configure
          an application's request pipeline*/
        /*IHostingEnvironment: Provides information about the web hosting
         environment an application is running in*/
        public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
        {
            // Checks if the current hosting environment name is Development
            if (hostingEnvironment.IsDevelopment())
            {
                /*This method is called to enable Browser Link in an application.
                 It registers a factory method that creates BrowserLinkMiddleware 
                 for each request*/
                applicationBuilder.UseBrowserLink();
                /*Captures synchronous and asynchronous Exception instances from
                 the pipeline and generates HTML error responses*/
                applicationBuilder.UseDeveloperExceptionPage();
            }
            else
            {
                /*Adds a middleware to the pipeline that will catch exceptions,
                 log them, and re-execute the request in an alternate pipeline. 
                 The request will not be re-executed if the response has already started*/
                applicationBuilder.UseExceptionHandler("/Home/Error");
            }

            // Enables static file serving for the current request path
            applicationBuilder.UseStaticFiles();

            /*Defines a contract for a route builder in an application.
             A route builder specifies the routes for an application*/
            void ConfigureRoutes(IRouteBuilder routes)
            {
                // Adds a route to the IRouteBuilder with the specified name and template
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            }
            // Adds MVC to the IApplicationBuilder request execution pipeline
            applicationBuilder.UseMvc(ConfigureRoutes);
        }

        public class LocalizationPipeline
        {
            public void Configure(IApplicationBuilder applicationBuilder)
            {
                // Using middleware in the filter pipeline
                // https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1#authorization-filters
                CultureInfo[] supportedCultures =
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("fr")
                };
                RequestLocalizationOptions options = new RequestLocalizationOptions
                {

                    DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US"),
                    SupportedCultures = supportedCultures,
                    SupportedUICultures = supportedCultures
                };
                options.RequestCultureProviders = new IRequestCultureProvider[]
                {
                    new RouteDataRequestCultureProvider
                    {
                        Options = options
                    }
                };
                applicationBuilder.UseRequestLocalization(options);
            }
        }
    }
}
