using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SessionSample.Middleware;
using System;

namespace SessionSample
{
    #region snippet1
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            /*Adds a default implementation of IDistributedCache that stores items
             in memory to the IServiceCollection. Frameworks that require a distributed 
             cache to work can safely add this dependency as part of their dependency 
             list to ensure that there is at least one implementation available.*/
            services.AddDistributedMemoryCache();

            // Adds services required for application session state.
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.Cookie.Name = ".AdventureWorks.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
            });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            // Adds the SessionMiddleware to automatically enable session state for the application.
            app.UseSession();
            // HttpContext.Items
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-2.1#httpcontextitems
            app.Use(async (context, next) =>
            {
                // perform some verification
                context.Items["isVerified"] = true;
                await next.Invoke();
                // Later in the pipeline, another middleware can access the value of isVerified:
                // Middleware/HttpContextItemsMiddleware.cs
            });
            app.UseHttpContextItemsMiddleware();
            app.UseMvc();
        }
    }
    #endregion
}
