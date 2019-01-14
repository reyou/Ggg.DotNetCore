using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace intro.IntroClasses
{
    public sealed class DynamicTenantIdentificationService : ITenantIdentificationService
    {
        private readonly Func<HttpContext, string> _currentTenant;
        private readonly Func<IEnumerable<string>> _allTenants;

        public DynamicTenantIdentificationService(Func<HttpContext, string> currentTenant, Func<IEnumerable<string>> allTenants)
        {
            if (allTenants != null)
            {
                _currentTenant = currentTenant ?? throw new ArgumentNullException(nameof(currentTenant));
                _allTenants = allTenants;
            }
            else
            {
                throw new ArgumentNullException(nameof(allTenants));
            }
        }

        public IEnumerable<string> GetAllTenants()
        {
            return _allTenants();
        }

        public string GetCurrentTenant(HttpContext context)
        {
            return _currentTenant(context);
        }
    }

}
