using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace intro.IntroClasses
{
    public interface ITenantConfiguration
    {
        /// <summary>
        /// Represents a set of key/value application configuration properties.
        /// </summary>
        /// <param name="configuration"></param>
        void Configure(IConfiguration configuration);
        /// <summary>
        /// Specifies the contract for a collection of service descriptors.
        /// </summary>
        /// <param name="services"></param>
        void ConfigureServices(IServiceCollection services);

        string Tenant { get; set; }
    }
}
