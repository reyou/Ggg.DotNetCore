using System.IO;
using fundamentalsProject.dependencyInjection;
using fundamentalsProject.middleware;
using fundamentalsProject.middleware.extensibility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace fundamentalsProject
{
    /// <summary>
    /// The Startup class is where you define the request handling pipeline
    /// and where any services needed by the app are configured.
    /// The Startup class must be public and contain the following methods:
    /// </summary>
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _config;
        private readonly ILoggerFactory _loggerFactory;


        public Startup(IHostingEnvironment env, IConfiguration config,
            ILoggerFactory loggerFactory)
        {
            _env = env;
            _config = config;
            _loggerFactory = loggerFactory;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// ConfigureServices defines the Services used by your app
        /// (for example, ASP.NET Core MVC, Entity Framework Core, Identity).
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            AddRouting(services);
            ILogger<Startup> logger = _loggerFactory.CreateLogger<Startup>();

            if (_env.IsDevelopment())
            {
                // Development service configuration

                logger.LogInformation("Development environment");
            }
            else
            {
                // Non-development service configuration

                logger.LogInformation($"Environment: {_env.EnvironmentName}");
            }

            services.AddDirectoryBrowser();

            services.AddTransient<IStartupFilter, RequestSetOptionsStartupFilter>();

            // dependency injection
            services.AddScoped<IMyDependency, MyDependency>();
            services.AddScoped<AppDbContext>();

            // default template services
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Factory-based middleware activation
            services.AddTransient<FactoryActivatedMiddleware>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-2.1#use-routing-middleware
        /// </summary>
        /// <param name="services"></param>
        private void AddRouting(IServiceCollection services)
        {
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configure defines the middleware called in the request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Routes must be configured in the Startup.Configure method. 
            ConfigureRoutes(app);

            // middleware
            app.Use(async (context, next) =>
            {
                // Do work that doesn't write to the Response.
                await next.Invoke();
                // Do logging or other work that doesn't write to the Response.
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-2.1&tabs=aspnetcore2x#serve-a-default-document
            app.UseDefaultFiles();

            // Use HTTPS Redirection Middleware to redirect HTTP requests to HTTPS.
            app.UseHttpsRedirection();

            // Return static files and end the pipeline.

            UseStaticFiles(env, app);
            RunFileExtensionContentTypeProvider(app);

            // http://localhost:50312/MyImages/
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
                RequestPath = "/MyImages"
            });

            // Use Cookie Policy Middleware to conform to EU General Data 
            //   Protection Regulation (GDPR) regulations.
            app.UseCookiePolicy();

            // Authenticate before the user accesses secure resources.
            // Authentication doesn't short-circuit unauthenticated requests.
            app.UseAuthentication();

            // map
            Map(app);

            // custom middleware
            app.UseRequestCulture();

            // Both middlewares are registered in the request processing pipeline in Configure:
            app.UseConventionalMiddleware();
            app.UseFactoryActivatedMiddleware();

            app.UseMvc();
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-2.1#reserved-routing-names
        /// </summary>
        /// <param name="app"></param>
        /// <param name="routes"></param>
        private void UrlGenerationReference(IApplicationBuilder app, IRouter routes)
        {
            app.Run(async (context) =>
            {
                RouteValueDictionary dictionary = new RouteValueDictionary
                {
                    { "operation", "create" },
                    { "id", 123}
                };

                VirtualPathContext vpc = new VirtualPathContext(context, null, dictionary,
                    "Track Package Route");
                var path = routes.GetVirtualPath(vpc).VirtualPath;

                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("Menu<hr/>");
                await context.Response.WriteAsync(
                    $"<a href='{path}'>Create Package 123</a><br/>");
            });
        }

        /// <summary>
        /// http://localhost:50312/package/create/3
        /// http://localhost:50312/hello/Joe
        /// </summary>
        /// <param name="app"></param>
        private void ConfigureRoutes(IApplicationBuilder app)
        {
            RouteHandler trackPackageRouteHandler = new RouteHandler(context =>
            {
                RouteValueDictionary routeValues = context.GetRouteData().Values;
                return context.Response.WriteAsync(
                    $"Hello! Route values: {string.Join(", ", routeValues)}");
            });
            RouteBuilder routeBuilder = new RouteBuilder(app, trackPackageRouteHandler);
            routeBuilder.MapRoute(
                "Track Package Route",
                "package/{operation:regex(^track|create|detonate$)}/{id:int}");
            routeBuilder.MapGet("hello/{name}", context =>
            {
                object name = context.GetRouteValue("name");
                // The route handler when HTTP GET "hello/<anything>" matches
                // To match HTTP GET "hello/<anything>/<anything>, 
                // use routeBuilder.MapGet("hello/{*name}"
                return context.Response.WriteAsync($"Hi, {name}!");
            });
            IRouter routes = routeBuilder.Build();
            // UrlGenerationReference(app, routes);
            app.UseRouter(routes);
        }

        private void RunFileExtensionContentTypeProvider(IApplicationBuilder app)
        {
            // Set up custom content types - associating file extension to MIME type
            FileExtensionContentTypeProvider provider = new FileExtensionContentTypeProvider();
            // Add new mappings
            provider.Mappings[".myapp"] = "application/x-msdownload";
            provider.Mappings[".htm3"] = "text/html";
            provider.Mappings[".image"] = "image/png";
            // Replace an existing mapping
            provider.Mappings[".rtf"] = "application/x-msdownload";
            // Remove MP4 videos.
            provider.Mappings.Remove(".mp4");

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
                RequestPath = "/MyImagesContentTypeProvider",
                ContentTypeProvider = provider
            });
        }

        private void Map(IApplicationBuilder app)
        {
            app.Map("/map1", HandleMapTest1);
            app.Map("/map2", HandleMapTest2);
            app.Map("/map1/seg1", HandleMultiSeg);
            app.Map("/level1", level1App =>
            {
                // http://localhost:50312/level1/level2a
                level1App.Map("/level2a", level2AApp =>
                {
                    // "/level1/level2a" processing
                    level2AApp.Run(async context =>
                    {
                        await context.Response.WriteAsync("/level1/level2a processing");
                    });

                });
                // http://localhost:50312/level1/level2b
                level1App.Map("/level2b", level2BApp =>
                {
                    // "/level1/level2b" processing
                    level2BApp.Run(async context =>
                    {
                        await context.Response.WriteAsync("/level1/level2b processing");
                    });
                });
            });

            // map when
            app.MapWhen(context => context.Request.Query.ContainsKey("branch"),
                HandleBranch);
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-2.1&tabs=aspnetcore2x#non-standard-content-types
        /// </summary>
        /// <param name="env"></param>
        /// <param name="app"></param>
        private void UseStaticFiles(IHostingEnvironment env, IApplicationBuilder app)
        {
            string cachePeriod = env.IsDevelopment() ? "600" : "604800";
            // For the wwwroot folder
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    // Requires the following import:
                    // using Microsoft.AspNetCore.Http;
                    ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cachePeriod}");
                }
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "MyStaticFiles")),
                RequestPath = "/StaticFiles"
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true,
                DefaultContentType = "image/png"
            });
        }

        private static void HandleMultiSeg(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map multiple segments.");
            });
        }

        /// <summary>
        /// http://localhost:50312/?branch=delta
        /// </summary>
        /// <param name="app"></param>
        private void HandleBranch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                StringValues branchVer = context.Request.Query["branch"];
                await context.Response.WriteAsync($"Branch used = {branchVer}");
            });
        }

        /// <summary>
        /// http://localhost:50312/map1
        /// </summary>
        /// <param name="app"></param>
        private static void HandleMapTest1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 1");
            });
        }

        /// <summary>
        /// http://localhost:50312/map2
        /// </summary>
        /// <param name="app"></param>
        private static void HandleMapTest2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 2");
            });
        }

    }
}
