using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace intro.IntroClasses
{
    public sealed class QueryStringTenantIdentificationService : ITenantIdentificationService
    {
        private readonly TenantMapping _tenants;

        public QueryStringTenantIdentificationService(IConfiguration configuration)
        {
            _tenants = configuration.GetTenantMapping();
        }

        public string GetCurrentTenant(HttpContext context)
        {
            string tenant = context.Request.Query["Tenant"].ToString();

            if (string.IsNullOrWhiteSpace(tenant) || !_tenants.Tenants.Values.Contains(tenant,
                    StringComparer.InvariantCultureIgnoreCase))
            {
                return _tenants.Default;
            }

            if (_tenants.Tenants.TryGetValue(tenant, out string mappedTenant))
            {
                return mappedTenant;
            }

            return tenant;
        }
    }
}
