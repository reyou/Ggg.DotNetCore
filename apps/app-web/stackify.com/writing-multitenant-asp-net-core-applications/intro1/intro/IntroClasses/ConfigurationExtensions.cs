using Microsoft.Extensions.Configuration;

namespace intro.IntroClasses
{
    public static class ConfigurationExtensions
    {
        public static TenantMapping GetTenantMapping(this IConfiguration configuration)
        {
            // Static helper class that allows binding strongly typed objects to configuration values.
            object o = configuration.GetSection("Tenants").Get(typeof(TenantMapping));
            return (TenantMapping)o;
        }
    }

}
