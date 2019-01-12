using GggWebApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GggWebApplication.Controllers.FilterExamples
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1#dependency-injection
    /// http://localhost:11781/DependencyInjectionSample
    /// </summary>
    public class DependencyInjectionSampleController : Controller
    {
        [ServiceFilter(typeof(AddHeaderFilterWithDi))]
        public IActionResult Index()
        {
            return View();
        }

    }
}
