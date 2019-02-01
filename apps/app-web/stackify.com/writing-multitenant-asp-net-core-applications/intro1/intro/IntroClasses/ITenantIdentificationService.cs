using Microsoft.AspNetCore.Http;

namespace intro.IntroClasses
{
    public interface ITenantIdentificationService
    {
        string GetCurrentTenant(HttpContext httpContext);
    }
}