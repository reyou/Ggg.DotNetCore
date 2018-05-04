using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GggWebApplication
{
    public class Startup
    {
        // Represents a set of key/value application configuration properties
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Specifies the contract for a collection of service descriptors
        public void ConfigureServices(IServiceCollection services)
        {
            // Adds MVC services to the specified IServiceCollection
            services.AddMvc();
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
    }
}
