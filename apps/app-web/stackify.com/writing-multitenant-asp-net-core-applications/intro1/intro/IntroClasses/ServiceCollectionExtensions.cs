using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace intro.IntroClasses
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTenantConfiguration(this IServiceCollection services, Assembly assembly)
        {
            IEnumerable<Type> types = assembly
                // An array that represents the types defined in this assembly that are visible outside the assembly.
                .GetExportedTypes()
                // Determines whether an instance of a specified type can be assigned to an instance of the current type.
                .Where(type => typeof(ITenantConfiguration).IsAssignableFrom(type))
                .Where(type => (type.IsAbstract == false) && (type.IsInterface == false));

            services.AddScoped(typeof(ITenantConfiguration), sp =>
            {
                ITenantService svc = sp.GetRequiredService<ITenantService>();
                IConfiguration configuration = sp.GetRequiredService<IConfiguration>();
                string tenant = svc.GetCurrentTenant();
                ITenantConfiguration instance = types
                    .Select(type => ActivatorUtilities.CreateInstance(sp, type))
                    .OfType<ITenantConfiguration>()
                    .SingleOrDefault(x => x.Tenant == tenant);

                if (instance != null)
                {
                    instance.Configure(configuration);
                    instance.ConfigureServices(services);

                    sp.GetRequiredService<IHttpContextAccessor>().HttpContext.RequestServices = services.BuildServiceProvider();
                    return instance;
                }
                else
                {
                    return DummyTenantServiceProviderConfiguration.Instance;
                }
            });

            return services;
        }

        public static IServiceCollection AddTenantConfiguration<T>(this IServiceCollection services)
        {
            Assembly assembly = typeof(T).Assembly;
            return services.AddTenantConfiguration(assembly);
        }
    }

    public class DummyTenantServiceProviderConfiguration
    {
        public static object Instance { get; set; }
    }
}
