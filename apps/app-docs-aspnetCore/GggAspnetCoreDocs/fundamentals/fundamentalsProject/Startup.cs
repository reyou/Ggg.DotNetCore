using System.Threading.Tasks;
using fundamentalsProject.dependencyInjection;
using fundamentalsProject.middleware;
using fundamentalsProject.middleware.extensibility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            services.AddTransient<IStartupFilter, RequestSetOptionsStartupFilter>();

            // dependency injection
            services.AddScoped<IMyDependency, MyDependency>();

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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configure defines the middleware called in the request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
            // Use HTTPS Redirection Middleware to redirect HTTP requests to HTTPS.
            app.UseHttpsRedirection();

            // Return static files and end the pipeline.
            app.UseStaticFiles();

            // Use Cookie Policy Middleware to conform to EU General Data 
            //   Protection Regulation (GDPR) regulations.
            app.UseCookiePolicy();

            // Authenticate before the user accesses secure resources.
            // Authentication doesn't short-circuit unauthenticated requests.
            app.UseAuthentication();

            // map
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

            // custom middleware
            app.UseRequestCulture();

            // Both middlewares are registered in the request processing pipeline in Configure:
            app.UseConventionalMiddleware();
            app.UseFactoryActivatedMiddleware();

            app.UseMvc();
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
