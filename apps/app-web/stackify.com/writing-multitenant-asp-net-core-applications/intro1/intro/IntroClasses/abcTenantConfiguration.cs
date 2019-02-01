using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace intro.IntroClasses
{
    /// <summary>
    /// abcTenantConfiguration
    /// </summary>
    public sealed class abcTenantConfiguration : ITenantConfiguration
    {
        public string Tenant
        {
            get => "abc";
            set => throw new NotImplementedException();
        }

        public void Configure(IConfiguration configuration)
        {
            configuration["StringOption"] = "abc";
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMyService, XptoService>();
        }

    }
}
