using System.Diagnostics;
using intro.IntroClasses;
using Microsoft.AspNetCore.Mvc;
using intro.Models;
using Microsoft.Extensions.Options;

namespace intro.Controllers
{
    public class HomeController : Controller
    {
        // IOptionsSnapshot Used to access the value of TOptions for the lifetime of a request
        public HomeController(IOptionsSnapshot<TenantConfig> settings, ITenantService service)
        {
            string tenant = service.GetCurrentTenant();
            TenantConfig tenantSettings = settings.Get(tenant);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
