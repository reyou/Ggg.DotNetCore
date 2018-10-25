using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CookieSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizePage("/Contact");
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            /*
             * https://docs.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-2.1&tabs=aspnetcore2x
             */
            #region snippet1
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.EventsType = typeof(CustomCookieAuthenticationEvents);
                });
            services.AddScoped<CustomCookieAuthenticationEvents>();

            #endregion

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            /*
             * https://docs.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-2.1&tabs=aspnetcore2x#cookie-policy-middleware
             */
            // app.UseCookiePolicy();

            // Call UseAuthentication before calling UseMVC.
            #region snippet2
            app.UseAuthentication();
            #endregion

            app.UseMvc();
        }
    }

    public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
    {


        public CustomCookieAuthenticationEvents()
        {
            // Get the database from registered DI services.

        }

        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            ClaimsPrincipal userPrincipal = context.Principal;
            // Look for the LastChanged claim.


            if (false)
            {
                context.RejectPrincipal();

                await context.HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }

        }
    }

}
