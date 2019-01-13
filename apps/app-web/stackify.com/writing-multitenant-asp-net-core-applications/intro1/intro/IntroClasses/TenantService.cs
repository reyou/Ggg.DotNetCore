using Microsoft.AspNetCore.Http;

namespace intro.IntroClasses
{
    public sealed class TenantService : ITenantService
    {
        // Encapsulates all HTTP-specific information about an individual HTTP request.
        private readonly HttpContext _httpContext;
        private readonly ITenantIdentificationService _service;

        public TenantService(IHttpContextAccessor accessor, ITenantIdentificationService service)
        {
            _httpContext = accessor.HttpContext;
            _service = service;
        }
        public string GetCurrentTenant()
        {
            return _service.GetCurrentTenant(_httpContext);
        }

    }
}