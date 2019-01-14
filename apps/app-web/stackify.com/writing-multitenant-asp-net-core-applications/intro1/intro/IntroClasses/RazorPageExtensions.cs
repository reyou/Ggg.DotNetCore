using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;

namespace intro.IntroClasses
{
    public static class RazorPageExtensions
    {
        public static T GetValueForTenant<T>(this IRazorPage page, string setting, T defaultValue = default(T))
        {
            ITenantService service = (ITenantService)page.ViewContext.HttpContext.RequestServices.GetService(typeof(T));
            string tenant = service.GetCurrentTenant();
            IConfiguration configuration = (IConfiguration)page.ViewContext.HttpContext.RequestServices.GetService(typeof(IConfiguration));
            var section = configuration.GetSection("Tenants").GetSection(tenant);

            if (section.Exists())
            {
                return section.GetValue(setting, defaultValue);
            }
            else
            {
                return configuration.GetValue(setting, defaultValue);
            }
        }
    }

}
